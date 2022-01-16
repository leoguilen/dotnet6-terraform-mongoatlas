namespace CarRent.Query.Api.Features.CarsCatalog.Models.Queries;

public record GetCarsQuery
{
    [FromQuery(Name = "manufactures")]
    public string[]? ManufacturesName { get; init; }

    [FromQuery(Name = "make")]
    public string? MakeName { get; init; }

    [FromQuery(Name = "model")]
    public string? ModelName { get; init; }

    [FromQuery(Name = "year")]
    public int? YearNumber { get; init; }

    [FromQuery(Name = "colors")]
    public string[]? ColorName { get; init; }

    [FromQuery(Name = "additionals")]
    public string[]? AdditionalDetails { get; init; }
}
