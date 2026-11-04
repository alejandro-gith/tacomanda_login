using Tacomanda.Domain.Empleados;
using Tacomanda.Domain.Mesas;
using Tacomanda.Domain.Platillos;

namespace Tacomanda.Infrastructure.Seed;

public interface IDatosDePruebaRepository
{
    Task<bool> ExistenAsync(CancellationToken cancellationToken);

    Task GuardarAsync(
        IReadOnlyCollection<Empleado> empleados,
        IReadOnlyCollection<Mesa> mesas,
        IReadOnlyCollection<Platillo> platillos,
        CancellationToken cancellationToken);
}
