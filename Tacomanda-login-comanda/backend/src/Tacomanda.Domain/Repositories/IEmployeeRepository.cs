namespace Tacomanda.Domain;

public interface IEmployeeRepository
{
    Task<IReadOnlyList<Employee>> ListActiveAsync(CancellationToken ct);
    Task<Employee?> FindAsync(Guid id, CancellationToken ct);
}
