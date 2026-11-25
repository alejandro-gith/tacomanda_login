using Tacomanda.Domain.Platillos;

namespace Tacomanda.Domain.Interfaces;

public interface IPlatilloRepository
{
    Task<Platillo?> ObtenerAsync(int id, CancellationToken cancellationToken);
}
