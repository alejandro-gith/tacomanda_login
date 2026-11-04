namespace Tacomanda.Domain;

public interface IOrderRepository
{
    Task AddAsync(Order order, CancellationToken ct);
    int NextNumber();
}
