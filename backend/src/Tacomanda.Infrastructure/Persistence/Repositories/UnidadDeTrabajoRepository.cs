using Tacomanda.Domain.Interfaces;

namespace Tacomanda.Infrastructure.Persistence.Repositories;

public sealed class UnidadDeTrabajoRepository : IUnidadDeTrabajo
{
    private readonly TacomandaDbContext _context;

    public UnidadDeTrabajoRepository(TacomandaDbContext context)
    {
        _context = context;
    }

    public async Task ConfirmarAsync(CancellationToken cancellationToken)
    {
        // Los repositorios comparten contexto scoped y una confirmación transaccional.
        await _context.SaveChangesAsync(cancellationToken);
    }
}
