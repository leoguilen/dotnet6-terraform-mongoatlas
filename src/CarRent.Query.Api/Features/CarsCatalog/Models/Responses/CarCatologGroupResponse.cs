namespace CarRent.Query.Api.Features.CarsCatalog.Models.Responses;

public record CarCatologGroupResponse
{
    public string ManufactureName { get; internal init; }

    public CarCatalogItemResponse[] Cars { get; internal init; }
}
