namespace Tacomanda.Domain;

public interface IDishRepository
{
    Task<IReadOnlyList<Dish>> ListAsync(bool activeOnly, CancellationToken ct);
    Task<Dish?> FindAsync(Guid id, CancellationToken ct);
}
