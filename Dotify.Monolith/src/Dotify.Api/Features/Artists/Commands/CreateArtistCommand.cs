using Dotify.Api.Features.Artists.Data;
using Dotify.Core.Artists.Commands;
using Dotify.Core.Artists.Entities;

using FluentValidation;

using MongoDB.Bson;

namespace Dotify.Api.Features.Artists.Commands;

public class CreateArtistCommand : ICreateArtistCommand<ArtistDto>
{
    private readonly ArtistCollection _collection;

    public CreateArtistCommand(ArtistCollection collection) => _collection = collection;

    public async Task<ArtistDto> ExecuteAsync(string name, List<string> genres)
    {
        var id = ObjectId.GenerateNewId().ToString();
        var artist = new Artist(id, name)
        {
            Genres = genres
        };

        await _collection.Artists.InsertOneAsync(artist);
        return new ArtistDto(artist);
    }
}

public record CreateArtist(string Name, List<string>? Genres);
public class CreateArtistValidator : AbstractValidator<CreateArtist>
{
    public CreateArtistValidator()
    {
        RuleFor(x => x.Name).NotEmpty();
    }
}