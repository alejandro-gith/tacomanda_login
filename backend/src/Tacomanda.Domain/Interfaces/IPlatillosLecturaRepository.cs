using Tacomanda.Domain.Platillos;

namespace Tacomanda.Domain.Interfaces;

public interface IPlatillosLecturaRepository
{
    Task<IReadOnlyList<Platillo>> ListarAsync(CancellationToken cancellationToken);
}
