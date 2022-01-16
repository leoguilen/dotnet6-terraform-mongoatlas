namespace CarRent.Query.Api.Features.CarsCatalog.Endpoints;

public class GetCarById : BaseAsyncEndpoint
    .WithRequest<Guid>
    .WithResponse<CarCatalogItemResponse>
{
    private readonly ICarsCatalogRepository _carsCatalogRepository;

    public GetCarById(ICarsCatalogRepository carsCatalogRepository)
        => _carsCatalogRepository = carsCatalogRepository;

    [HttpGet("cars/{carId:Guid}")]
    [SwaggerOperation(
        Summary = "Get car by id",
        Description = "Get car by id",
        OperationId = "Cars.GetById",
        Tags = new[] { "GetCarByIdEndpoint" })]
    public override async Task<ActionResult<CarCatalogItemResponse>> HandleAsync(
        [FromRoute(Name = "carId")] Guid carId,
        CancellationToken cancellationToken = default)
    {
        var car = await _carsCatalogRepository
            .GetByAsync(carId, cancellationToken);

        return car is null
            ? NotFound()
            : Ok(car);
    }
}
