using Microsoft.EntityFrameworkCore;
using Tacomanda.Domain.Cierres;
using Tacomanda.Domain.Interfaces;
using Tacomanda.Domain.Pagos;

namespace Tacomanda.Infrastructure.Persistence.Repositories;

public sealed class CierresLecturaRepository : ICierresLecturaRepository
{
    private readonly TacomandaDbContext _context;
    public CierresLecturaRepository(TacomandaDbContext context) { _context = context; }

    public async Task<decimal> TotalPendienteAsync(CancellationToken cancellationToken)
    {
        DateTimeOffset? ultimo = await _context.Set<CierreCaja>().AsNoTracking()
            .OrderByDescending(c => c.FechaHora)
            .Select(c => (DateTimeOffset?)c.FechaHora)
            .FirstOrDefaultAsync(cancellationToken);
        IQueryable<Pago> pagos = _context.Set<Pago>().AsNoTracking()
            .Where(p => p.Forma == "Efectivo");
        if (ultimo.HasValue) pagos = pagos.Where(p => p.Fecha > ultimo.Value);
        decimal? total = await pagos.SumAsync(p => (decimal?)(p.Monto - p.Cambio), cancellationToken);
        return total ?? 0;
    }
}
