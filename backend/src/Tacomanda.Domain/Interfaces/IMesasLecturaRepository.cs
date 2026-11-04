using Tacomanda.Domain.Mesas;

namespace Tacomanda.Domain.Interfaces;

public interface IMesasLecturaRepository
{
    Task<IReadOnlyList<Mesa>> ListarAsync(CancellationToken cancellationToken);
}
