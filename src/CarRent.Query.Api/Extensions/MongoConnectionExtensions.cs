namespace CarRent.Query.Api.Extensions;

internal static class MongoConnectionExtensions
{
    public static IServiceCollection AddMongoClient(
        this IServiceCollection services,
        IConfiguration configuration)
        => services.AddScoped(_ =>
        {
            var mongoUrl = MongoUrl.Create(configuration.GetConnectionString("CarRentStoreDb"));
            var mongoClient = new MongoClient(mongoUrl);

            return mongoClient.GetDatabase(mongoUrl.DatabaseName);
        });
}
