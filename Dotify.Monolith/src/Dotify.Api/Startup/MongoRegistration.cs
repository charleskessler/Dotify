
using MongoDB.Bson.Serialization;
using MongoDB.Bson.Serialization.IdGenerators;
using MongoDB.Driver;

namespace Dotify.Api.Startup;

public static class MongoRegistration
{
    public static MongoClient GetMongoClient(string connectionString = "mongodb://localhost")
    {
        return new MongoClient(connectionString);
    }

    public static IServiceCollection AddMongo(this IServiceCollection services, string connectionString = "mongodb://localhost")
    {
        var mongoClient = GetMongoClient(connectionString);
        services.AddSingleton(c => mongoClient.GetDatabase("dotify-monolith"));
        services.AddMongoCollections();
        services.AddMongoRepositories();
        RegisterMongoInternals();

        return services;
    }

    private static void RegisterMongoInternals()
    {
        BsonSerializer.RegisterIdGenerator(typeof(string), StringObjectIdGenerator.Instance);
    }

    private static IServiceCollection AddMongoCollections(this IServiceCollection services)
    {
        return services;
    }

    private static IServiceCollection AddMongoRepositories(this IServiceCollection services)
    {
        return services;
    }
}
