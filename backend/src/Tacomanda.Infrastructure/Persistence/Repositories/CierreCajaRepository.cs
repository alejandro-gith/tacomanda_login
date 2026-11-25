using Tacomanda.Domain.Cierres;
using Tacomanda.Domain.Interfaces;

namespace Tacomanda.Infrastructure.Persistence.Repositories;

public sealed class CierreCajaRepository : ICierreCajaRepository
{
    private readonly TacomandaDbContext _context;
    public CierreCajaRepository(TacomandaDbContext context) { _context = context; }
    public void Agregar(CierreCaja cierre) { _context.Set<CierreCaja>().Add(cierre); }
}
