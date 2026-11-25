using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
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

    public async Task AgregarConFolioAsync(Comanda comanda, CancellationToken ct)
    {
        // La fecha de operación corresponde al local, aunque la fecha persistida sea UTC.
        TimeZoneInfo zona = TimeZoneInfo.FindSystemTimeZoneById("America/Mexico_City");
        DateOnly fecha = DateOnly.FromDateTime(TimeZoneInfo.ConvertTime(comanda.FechaCreacion, zona).DateTime);
        DateTime fechaSql = fecha.ToDateTime(TimeOnly.MinValue);

        await using IDbContextTransaction transaccion = await _context.Database.BeginTransactionAsync(ct);
        // El contador de esta fecha se incrementa bajo bloqueo en la misma transacción
        // que guarda la comanda y ocupa la mesa. LAST_INSERT_ID() es local a la conexión.
        await _context.Database.ExecuteSqlInterpolatedAsync(
            $"INSERT INTO folios_diarios (fecha, ultimo_numero) VALUES ({fechaSql}, LAST_INSERT_ID(1)) ON DUPLICATE KEY UPDATE ultimo_numero = LAST_INSERT_ID(ultimo_numero + 1)", ct);
        int numero = await _context.Database.SqlQueryRaw<int>("SELECT LAST_INSERT_ID() AS Value")
            .SingleAsync(ct);
        comanda.AsignarNumeroDiario(fecha, numero);
        _context.Set<Comanda>().Add(comanda);
        await _context.SaveChangesAsync(ct);
        await transaccion.CommitAsync(ct);
    }

    public Task<Comanda?> ObtenerAsync(int id, CancellationToken ct) =>
        _context.Set<Comanda>().Include(c => c.Detalles).SingleOrDefaultAsync(c => c.Id == id, ct);

}
