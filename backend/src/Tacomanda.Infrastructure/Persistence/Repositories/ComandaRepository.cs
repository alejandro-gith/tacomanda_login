using Tacomanda.Domain.Comandas;
using Tacomanda.Domain.Interfaces;

namespace Tacomanda.Infrastructure.Persistence.Repositories;

public sealed class ComandaRepository : IComandaRepository
{
    private readonly TacomandaDbContext _context;

    public ComandaRepository(TacomandaDbContext context)
    {
        _context = context;
    }

    public void Agregar(Comanda comanda)
    {
        _context.Set<Comanda>().Add(comanda);
    }
}
