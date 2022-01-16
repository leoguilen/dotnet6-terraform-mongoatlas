using System.Text.Json.Serialization;

namespace CarRent.Query.Api.Features.CarsCatalog.Models.Responses;

public record CarCatalogItemResponse
{
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string ManufactureName { get; internal init; }

    public Guid CarId { get; internal init; }

    public string MakeName { get; internal init; }

    public string ModelName { get; internal init; }

    public int Year { get; internal init; }

    public string Color { get; internal init; }

    public string[] AdditionalDetails { get; internal init; }

    public string ImageUrl { get; internal init; }
}
