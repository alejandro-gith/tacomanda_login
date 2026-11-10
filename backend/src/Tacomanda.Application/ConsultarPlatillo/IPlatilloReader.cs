using Tacomanda.Domain.Platillos;

namespace Tacomanda.Application.ConsultarPlatillo;

public interface IPlatilloReader
{
    Task<IReadOnlyList<Platillo>> LeerAsync(CancellationToken cancellationToken);
}
