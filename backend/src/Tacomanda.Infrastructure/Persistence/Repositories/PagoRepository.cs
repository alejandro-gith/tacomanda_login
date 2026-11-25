using Tacomanda.Domain.Interfaces;
using Tacomanda.Domain.Pagos;

namespace Tacomanda.Infrastructure.Persistence.Repositories;

public sealed class PagoRepository : IPagoRepository
{
    private readonly TacomandaDbContext _context;
    public PagoRepository(TacomandaDbContext context) { _context = context; }
    public void Agregar(Pago pago) { _context.Set<Pago>().Add(pago); }
}
