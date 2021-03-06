# Dotify

## What is it?
The goal of this project is to document the iterative process of implementing and scaling an API by first building a monolithic structure, and then refactoring to distributed microservices.

Since this project is focused on implementing an API, rather than designing one, we will be using the [Spotify Public API](https://developer.spotify.com/documentation/web-api/) as a reference for our functional requirements and data model.

## Overview
### Monolith
An application that is designed to run within a single process, on a single server, with a single database schema.

#### What We'll Use To Build It
- [Clean Architecture](https://blog.cleancoder.com/uncle-bob/2012/08/13/the-clean-architecture.html) (aka [Onion Architecture, Ports & Adapters, Hexagonal Architecture](https://en.wikipedia.org/wiki/Hexagonal_architecture_(software)))
- [ASP.NET Core Minimal API](https://docs.microsoft.com/en-us/aspnet/core/fundamentals/minimal-apis?view=aspnetcore-6.0)
  - Supplemented by [Carter](https://github.com/CarterCommunity/Carter)
- [MongoDB](https://docs.mongodb.com/)
- [Mediatr](https://github.com/jbogard/MediatR)


### Microservices
blahblhablh

#### What We'll Use To Build It
- [MassTransit](https://masstransit-project.com/)
- [RabbitMQ](https://www.rabbitmq.com/)
- [Azure](https://docs.microsoft.com/en-us/azure/app-service/quickstart-dotnetcore?tabs=net60&pivots=development-environment-vs)




## Exploring The Spotify Data Model
Let's jump right in and start playing with the [Spotify Developer Console](https://developer.spotify.com/console/) to get a feel for the types of queries and commands we can execute, and the data models that are returned.

### Artist
Try out the [Get Artist](https://developer.spotify.com/console/get-artist/?id=5wFXmYsg3KFJ8BDsQudJ4f) console:

```json
{
    "external_urls": {
      "spotify": "https://open.spotify.com/artist/5wFXmYsg3KFJ8BDsQudJ4f"
    },
    "followers": {
      "href": null,
      "total": 427177
    },
    "genres": [
      "indie rock"
    ],
    "href": "https://api.spotify.com/v1/artists/5wFXmYsg3KFJ8BDsQudJ4f",
    "id": "5wFXmYsg3KFJ8BDsQudJ4f",
    "images": [
      {
        "height": 640,
        "url": "https://i.scdn.co/image/ab6761610000e5eb642fbb74e3e7507c12d8b8fd",
        "width": 640
      },
      {
        "height": 320,
        "url": "https://i.scdn.co/image/ab67616100005174642fbb74e3e7507c12d8b8fd",
        "width": 320
      },
      {
        "height": 160,
        "url": "https://i.scdn.co/image/ab6761610000f178642fbb74e3e7507c12d8b8fd",
        "width": 160
      }
    ],
    "name": "Manchester Orchestra",
    "popularity": 64,
    "type": "artist",
    "uri": "spotify:artist:5wFXmYsg3KFJ8BDsQudJ4f"
  }
```

Look carefully among the sea of URLs and you'll find the information we care about right now:
- id
- name
- genres

We'll come back for the other properties later on, but this is a good starting point for our `Artist` entity:

```csharp
namespace Dotify.Core.Artists.Entities;

public interface IArtist
{
    string Id { get; set; }
    string Name { get; set; }
    List<string> Genres { get; set; }
}
```

#### `Artist` Module

We'll be organizing our API into Features, so let's go ahead and create our `Artist` feature and build out its API module.

##### GET Artists
First, we need to define an interface that abstracts the act of 'Querying For All `Artists`'. We do this in our Core project, so that we can implement it any way we need to. For instance, we might mockup an in-memory List for testing, or switch from MongoDB to CosmosDB, and nothing has to change.

```csharp

using Dotify.Core.Artists.Entities;

namespace Dotify.Core.Artists.Queries;

public interface IGetArtistsQuery
{
    IEnumerable<Artist> Execute();
}
```
Now, in our API project we can implement this interface using our MongoDB `Artist` collection:

```csharp
using Dotify.Api.Features.Artists.Data;
using Dotify.Core.Artists.Entities;
using Dotify.Core.Artists.Queries;

using MongoDB.Driver;

namespace Dotify.Api.Features.Artists.Queries;

public class GetArtistsQuery : IGetArtistsQuery<ArtistDto>
{
    private readonly ArtistCollection _collection;

    public GetArtistsQuery(ArtistCollection collection)
    {
        _collection = collection;
    }

    public async Task<IEnumerable<ArtistDto>> ExecuteAsync()
    {
        var filter = Builders<Artist>.Filter.Empty;
        var results = await _collection.Artists.FindAsync(filter);
        var artists = await results.ToListAsync();

        var artistDtos = new List<ArtistDto>(artists.Count);

        artists.ForEach(a => artistDtos.Add(new ArtistDto(a)));

        return artistDtos;
    }
}
```

Wire up our query into the MSDI `IServiceCollection`:
```csharp
services.AddSingleton<IGetArtistsQuery<ArtistDto>, GetArtistsQuery>();
```

Finally, let's create the API endpoint. We use Carter to simplify and enhance ASP.NET Core Minimal API -- it provides some handy functionality and extension methods for us to use.

```csharp
using Dotify.Api.Features.Artists.Data;
using Dotify.Core.Artists.Queries;

namespace Dotify.Api.Features.Artists.Modules;

public class ArtistModule : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapGet("/artists", async (IGetArtistsQuery<ArtistDto> getArtistsQuery, HttpResponse res) =>
        {
            var artists = await getArtistsQuery.ExecuteAsync();

            return artists;
        })
        .IncludeInOpenApi();
    }
}   
```                                            

### Response Objects

Analyzing the Spotify data model, we find many common fields which are shared across the majority of responses. 

For example, a [response for a query on a specific artist](https://developer.spotify.com/console/get-artist/?id=5wFXmYsg3KFJ8BDsQudJ4f):

```json
{
  "id": "5wFXmYsg3KFJ8BDsQudJ4f",
  "href": "https://api.spotify.com/v1/artists/5wFXmYsg3KFJ8BDsQudJ4f",
  "uri": "spotify:artist:5wFXmYsg3KFJ8BDsQudJ4f",
  "external_urls": {
    "spotify": "https://open.spotify.com/artist/5wFXmYsg3KFJ8BDsQudJ4f"
  },
  "type": "artist",
  ...
}
```
Contains various ways to link to the artist record:
- A unique ID
- A reference to the API endpoint where information on the artist can be found
- A URI which, presumably, is used for navigation within Spotify's applications
- An external URL which points to the Spotify Web Player

We'll ultimately utilize a better solution, but for now tack this on our Data Transfer Object (DTO) implementation of our `IArtist` entity, by implementing the `ILocatableEntity` interface:


```csharp
using Dotify.Core.Artists.Entities;
using Dotify.Core.Shared;

namespace Dotify.Api.Features.Artists.Data;

public class ArtistDto : IArtist, ILocatableEntity
{
    public string Id { get; set; }
    public List<string> Genres { get; set; }
    public string Name { get; set; }
    public string Href { get; }
    public string Uri { get; }
    public string Type { get; }

    public ArtistDto(IArtist a)
    {
        Id = a.Id;
        Name = a.Name;
        Genres = a.Genres;
        Type = a.GetType().Name.ToLower();
        Href = $"https://localhost:7122/artists/{a.Id}";
        Uri = $"dotify:artists:{a.Id}";
    }
}
```