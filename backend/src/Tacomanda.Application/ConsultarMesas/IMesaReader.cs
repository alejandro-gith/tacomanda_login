using Tacomanda.Domain.Mesas;

namespace Tacomanda.Application.ConsultarMesas;

public interface IMesaReader
{
    Task<IReadOnlyList<Mesa>> LeerAsync(CancellationToken cancellationToken);
}
