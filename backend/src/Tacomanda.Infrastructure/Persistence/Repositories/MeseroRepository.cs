using Microsoft.EntityFrameworkCore;
using Tacomanda.Domain.Empleados;
using Tacomanda.Domain.Interfaces;

namespace Tacomanda.Infrastructure.Persistence.Repositories;

public sealed class MeseroRepository : IMeseroRepository
{
    private readonly TacomandaDbContext _context;

    public MeseroRepository(TacomandaDbContext context)
    {
        _context = context;
    }

    public async Task<Empleado?> ObtenerAsync(Guid id, CancellationToken cancellationToken)
    {
        return await _context.Set<Empleado>()
            .FindAsync(new object[] { id }, cancellationToken);
    }
}
