using Tacomanda.Domain.Comandas;

namespace Tacomanda.Domain.Interfaces;

public interface IComandaRepository
{
    Task AgregarConFolioAsync(Comanda comanda, CancellationToken ct);
    Task<Comanda?> ObtenerAsync(int id, CancellationToken ct);
}
