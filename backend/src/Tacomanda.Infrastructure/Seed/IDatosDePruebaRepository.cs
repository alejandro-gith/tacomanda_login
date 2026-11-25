using Tacomanda.Domain.Empleados;

namespace Tacomanda.Infrastructure.Seed;

public interface IDatosDePruebaRepository
{
    Task<bool> ExistenAsync(CancellationToken cancellationToken);
    Task GuardarAsync(IReadOnlyCollection<Empleado> empleados, CancellationToken cancellationToken);
}
