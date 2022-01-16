namespace CarRent.Query.Api.Repositories;

internal class MongoDbCarsCatalogRepository : ICarsCatalogRepository
{
    private const string CarsCatalogCollectionName = "CARS_CATALOG";

    private readonly IMongoCollection<BsonDocument> _carsCatalogCollection;

    public MongoDbCarsCatalogRepository(IMongoDatabase mongoDatabase)
        => _carsCatalogCollection = mongoDatabase
                .GetCollection<BsonDocument>(CarsCatalogCollectionName);

    public async Task<IReadOnlyList<CarCatalogItemResponse>> GetAllAsync(GetCarsQuery query, CancellationToken cancellationToken)
    {
        //var searchQuery = string.Join(
        //    separator: ',',
        //    string.Join(',', query?.ManufacturesName),
        //    query?.MakeName,
        //    query?.ModelName,
        //    query?.YearNumber,
        //    string.Join(',', query?.ColorName),
        //    string.Join(',', query?.AdditionalDetails));
        var pipelineDefinitions = PipelineDefinition<BsonDocument, BsonDocument>
            .Create(new BsonDocument[]
            {
                new BsonDocument("$search",
                    new BsonDocument
                        {
                            { "index", "cars_catalog_search_index" },
                            { "text",
                    new BsonDocument
                            {
                                { "query", $"{searchQuery}" },
                                { "path",
                    new BsonDocument("wildcard", "*") }
                            } }
                        }),
                new BsonDocument("$sort",
                    new BsonDocument("MANUFACTURER_NAME", 1))
            });

        var bsonDocsFetched = await _carsCatalogCollection
            .AggregateAsync(pipelineDefinitions, options: null, cancellationToken);

        return await CreateListOfCarsFromAsync(bsonDocsFetched, cancellationToken);
    }

    public async Task<IReadOnlyList<CarCatologGroupResponse>> GetAllGroupedAsync(CancellationToken cancellationToken)
    {
        var pipelineDefinition = PipelineDefinition<BsonDocument, BsonDocument>
            .Create(new BsonDocument[]
            {
                new BsonDocument("$group",
                    new BsonDocument
                    {
                        { "_id", "$MANUFACTURER_NAME" },
                        { "CARS",
                            new BsonDocument("$push", "$$ROOT") }
                        }),
                new BsonDocument("$project",
                    new BsonDocument
                    {
                        { "_id", 0 },
                        { "MANUFACTURER_NAME", "$_id" },
                        { "CARS", 1 }
                    }),
                new BsonDocument("$project",
                    new BsonDocument
                    {
                        { "CARS._id", 0 },
                        { "CARS.MANUFACTURER_NAME", 0 },
                        { "CARS.CREATED_AT", 0 },
                        { "CARS.CREATED_BY", 0 }
                    })
            });

        var bsonDocsFetched = await _carsCatalogCollection
            .AggregateAsync(pipelineDefinition, options: null, cancellationToken);

        return await CreateGroupedListOfCarsFromAsync(bsonDocsFetched, cancellationToken);
    }

    public async Task<CarCatalogItemResponse> GetByAsync(Guid carId, CancellationToken cancellationToken)
    {
        var filter = Builders<BsonDocument>.Filter.Eq("CAR_UUID", carId.ToString());
        var bsonDocsFetched = await _carsCatalogCollection
            .FindAsync(filter, options: null, cancellationToken);

        return (await CreateListOfCarsFromAsync(bsonDocsFetched, cancellationToken)).FirstOrDefault();
    }

    public async Task<CarCatologGroupResponse> GetGroupedByAsync(string manufactureName, CancellationToken cancellationToken)
    {
        var pipelineDefinition = PipelineDefinition<BsonDocument, BsonDocument>
            .Create(new BsonDocument[]
            {
                new BsonDocument("$group",
                    new BsonDocument
                    {
                        { "_id", "$MANUFACTURER_NAME" },
                        { "CARS",
                            new BsonDocument("$push", "$$ROOT") }
                        }),
                new BsonDocument("$match",
                    new BsonDocument("_id", manufactureName)),
                new BsonDocument("$project",
                    new BsonDocument
                    {
                        { "_id", 0 },
                        { "MANUFACTURER_NAME", "$_id" },
                        { "CARS", 1 }
                    }),
                new BsonDocument("$project",
                    new BsonDocument
                    {
                        { "CARS._id", 0 },
                        { "CARS.MANUFACTURER_NAME", 0 },
                        { "CARS.CREATED_AT", 0 },
                        { "CARS.CREATED_BY", 0 }
                    })
            });

        var bsonDocsFetched = await _carsCatalogCollection
            .AggregateAsync(pipelineDefinition, options: null, cancellationToken);

        return (await CreateGroupedListOfCarsFromAsync(bsonDocsFetched, cancellationToken)).FirstOrDefault();
    }
}
