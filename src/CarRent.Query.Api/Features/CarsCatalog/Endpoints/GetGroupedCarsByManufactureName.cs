namespace CarRent.Query.Api.Features.CarsCatalog.Endpoints;

public class GetGroupedCarsByManufactureName : BaseAsyncEndpoint
    .WithRequest<string>
    .WithResponse<CarCatologGroupResponse>
{
    private readonly ICarsCatalogRepository _carsCatalogRepository;

    public GetGroupedCarsByManufactureName(ICarsCatalogRepository carsCatalogRepository)
        => _carsCatalogRepository = carsCatalogRepository;

    [HttpGet("cars/grouped/{manufactureName}")]
    [SwaggerOperation(
        Summary = "Get grouped cars by manufacture name",
        Description = "Get grouped cars by manufacture name",
        OperationId = "Cars.GetByManufactureName",
        Tags = new[] { "GetGroupedCarsByManufactureNameEndpoint" })]
    public override async Task<ActionResult<CarCatologGroupResponse>> HandleAsync(
        [FromRoute(Name = "manufactureName")] string manufactureName,
        CancellationToken cancellationToken = default)
    {
        var groupedCars = await _carsCatalogRepository
            .GetGroupedByAsync(manufactureName, cancellationToken);

        return groupedCars is null
            ? NotFound()
            : Ok(groupedCars);
    }
}
