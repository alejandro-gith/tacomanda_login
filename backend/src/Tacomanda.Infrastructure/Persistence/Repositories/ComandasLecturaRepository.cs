using Microsoft.EntityFrameworkCore;
using Tacomanda.Domain.Comandas;
using Tacomanda.Domain.Interfaces;

namespace Tacomanda.Infrastructure.Persistence.Repositories;

public sealed class ComandasLecturaRepository : IComandasLecturaRepository
{
    private readonly TacomandaDbContext _context;
    public ComandasLecturaRepository(TacomandaDbContext context) { _context = context; }

    public Task<Comanda?> ObtenerAsync(int id, CancellationToken ct) =>
        _context.Set<Comanda>().AsNoTracking().Include(c => c.Detalles)
            .SingleOrDefaultAsync(c => c.Id == id, ct);

    public async Task<IReadOnlyList<Comanda>> ListarAsync(int? meseroId, OrderStatus? estado, bool soloCocina, CancellationToken ct)
    {
        IQueryable<Comanda> consulta = _context.Set<Comanda>().AsNoTracking();
        if (meseroId is int id) consulta = consulta.Where(c => c.MeseroId == id);
        if (estado is OrderStatus filtro) consulta = consulta.Where(c => c.Estado == filtro);
        if (soloCocina) consulta = consulta.Where(c => c.Estado != OrderStatus.Cobrada);
        List<Comanda> comandas = await consulta.Include(c => c.Detalles).ToListAsync(ct);
        return comandas.OrderByDescending(c => c.FechaCreacion).ToList();
    }
}
