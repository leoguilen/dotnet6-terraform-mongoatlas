namespace CarRent.Query.Api.Factories;

internal static class ResponseObjectsFactory
{
    public static async Task<IReadOnlyList<CarCatalogItemResponse>> CreateListOfCarsFromAsync(
        IAsyncCursor<BsonDocument> bsonDocuments,
        CancellationToken cancellationToken)
    {
        var listOfCars = Array.Empty<CarCatalogItemResponse>();

        while (await bsonDocuments.MoveNextAsync(cancellationToken))
        {
            foreach (var bsonDoc in bsonDocuments.Current)
            {
                Array.Resize(ref listOfCars, listOfCars.Length + 1);

                listOfCars[^1] = new CarCatalogItemResponse
                {
                    ManufactureName = bsonDoc["MANUFACTURER_NAME"].AsString,
                    CarId = Guid.Parse(bsonDoc["CAR_UUID"].AsString),
                    MakeName = bsonDoc["CAR_MAKE_NAME"].AsString,
                    ModelName = bsonDoc["CAR_MODEL_NAME"].AsString,
                    Year = bsonDoc["CAR_YEAR_NUMBER"].AsInt32,
                    Color = bsonDoc["CAR_COLOR_NAME"].AsString,
                    AdditionalDetails = bsonDoc["CAR_ADDITIONAL_DETAILS"].AsBsonArray.Select(value => value.AsString).ToArray(),
                    ImageUrl = bsonDoc["CAR_IMAGE_URL"].AsString,
                };
            }
        }

        return listOfCars;
    }

    public static async Task<IReadOnlyList<CarCatologGroupResponse>> CreateGroupedListOfCarsFromAsync(
        IAsyncCursor<BsonDocument> bsonDocuments,
        CancellationToken cancellationToken)
    {
        var groupedListOfCars = Array.Empty<CarCatologGroupResponse>();

        while (await bsonDocuments.MoveNextAsync(cancellationToken))
        {
            foreach (var bsonDoc in bsonDocuments.Current)
            {
                Array.Resize(ref groupedListOfCars, groupedListOfCars.Length + 1);

                var listOfCars = Array.Empty<CarCatalogItemResponse>();

                foreach (var carDoc in bsonDoc["CARS"].AsBsonArray)
                {
                    Array.Resize(ref listOfCars, listOfCars.Length + 1);

                    listOfCars[^1] = new CarCatalogItemResponse
                    {
                        CarId = Guid.Parse(carDoc["CAR_UUID"].AsString),
                        MakeName = carDoc["CAR_MAKE_NAME"].AsString,
                        ModelName = carDoc["CAR_MODEL_NAME"].AsString,
                        Year = carDoc["CAR_YEAR_NUMBER"].AsInt32,
                        Color = carDoc["CAR_COLOR_NAME"].AsString,
                        AdditionalDetails = carDoc["CAR_ADDITIONAL_DETAILS"].AsBsonArray.Select(value => value.AsString).ToArray(),
                        ImageUrl = carDoc["CAR_IMAGE_URL"].AsString,
                    };
                }

                groupedListOfCars[^1] = new CarCatologGroupResponse
                {
                    ManufactureName = bsonDoc["MANUFACTURER_NAME"].AsString,
                    Cars = listOfCars,
                };
            }
        }

        return groupedListOfCars;
    }
}
