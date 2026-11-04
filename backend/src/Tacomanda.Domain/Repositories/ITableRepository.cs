namespace Tacomanda.Domain;

public interface ITableRepository
{
    Task<IReadOnlyList<RestaurantTable>> ListAsync(CancellationToken ct);
    Task<RestaurantTable?> FindAsync(Guid id, CancellationToken ct);
    Task UpdateAsync(RestaurantTable table, CancellationToken ct);
}
