using Microsoft.EntityFrameworkCore;
using Tacomanda.Domain.Empleados;
using Tacomanda.Domain.Interfaces;

namespace Tacomanda.Infrastructure.Persistence.Repositories;

public sealed class EmpleadoRepository : IEmpleadoRepository
{
    private readonly TacomandaDbContext _context;

    public EmpleadoRepository(TacomandaDbContext context)
    {
        _context = context;
    }

    public async Task<Empleado?> BuscarPorUsuarioAsync(string usuario, CancellationToken cancellationToken)
    {
        return await _context.Set<Empleado>()
            .FromSqlInterpolated($"SELECT * FROM Empleados WHERE Usuario = {usuario}")
            .AsNoTracking()
            .SingleOrDefaultAsync(cancellationToken);
    }
}
