using Tacomanda.Domain.Mesas;

namespace Tacomanda.Domain.Interfaces;

public interface IMesaRepository
{
    Task<Mesa?> ObtenerAsync(int id, CancellationToken cancellationToken);
}
