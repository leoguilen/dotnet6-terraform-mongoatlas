namespace CarRent.Query.Api.Features.CarsCatalog.Endpoints;

public class GetAllCarsGrouped : BaseAsyncEndpoint
    .WithoutRequest
    .WithResponse<CarCatologGroupResponse[]>
{
    private readonly ICarsCatalogRepository _carsCatalogRepository;

    public GetAllCarsGrouped(ICarsCatalogRepository carsCatalogRepository)
        => _carsCatalogRepository = carsCatalogRepository;

    [HttpGet("cars/grouped")]
    [SwaggerOperation(
        Summary = "Get a grouped list of cars by manufacturer name",
        Description = "Get a grouped list of cars by manufacturer name",
        OperationId = "Cars.GetAllGrouped",
        Tags = new[] { "GetAllCarsGroupedEndpoint" })]
    public override async Task<ActionResult<CarCatologGroupResponse[]>> HandleAsync(CancellationToken cancellationToken = default)
        => Ok(await _carsCatalogRepository.GetAllGroupedAsync(cancellationToken));
}
