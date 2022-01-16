namespace CarRent.Query.Api.Features.CarsCatalog.Endpoints;

public class GetAllCars : BaseAsyncEndpoint
    .WithRequest<GetCarsQuery>
    .WithResponse<CarCatalogItemResponse[]>
{
    private readonly ICarsCatalogRepository _carsCatalogRepository;

    public GetAllCars(ICarsCatalogRepository carsCatalogRepository)
        => _carsCatalogRepository = carsCatalogRepository;

    [HttpGet("cars")]
    [SwaggerOperation(
        Summary = "Get a list of cars",
        Description = "Get a list of cars",
        OperationId = "Cars.GetAll",
        Tags = new[] { "GetAllCarsEndpoint" })]
    public override async Task<ActionResult<CarCatalogItemResponse[]>> HandleAsync(
        [FromQuery] GetCarsQuery query,
        CancellationToken cancellationToken = default)
        => Ok(await _carsCatalogRepository.GetAllAsync(query, cancellationToken));
}
