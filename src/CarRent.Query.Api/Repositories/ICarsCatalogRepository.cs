namespace CarRent.Query.Api.Repositories;

public interface ICarsCatalogRepository
{
    Task<IReadOnlyList<CarCatalogItemResponse>> GetAllAsync(GetCarsQuery query, CancellationToken cancellationToken);

    Task<CarCatalogItemResponse> GetByAsync(Guid carId, CancellationToken cancellationToken);

    Task<IReadOnlyList<CarCatologGroupResponse>> GetAllGroupedAsync(/* TODO: search params */CancellationToken cancellationToken);

    Task<CarCatologGroupResponse> GetGroupedByAsync(string manufactureName, CancellationToken cancellationToken);
}
