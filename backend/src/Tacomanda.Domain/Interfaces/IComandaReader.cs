using Tacomanda.Domain.Comandas;

namespace Tacomanda.Domain.Interfaces;

public interface IComandaReader
{
    Task<IReadOnlyList<Comanda>> ListarAsync(int? meseroId, OrderStatus? estado, bool soloCocina, CancellationToken ct);
    Task<Comanda?> ObtenerAsync(int id, CancellationToken ct);
}
