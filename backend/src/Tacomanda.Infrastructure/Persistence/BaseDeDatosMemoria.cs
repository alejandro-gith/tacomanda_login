using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;

namespace Tacomanda.Infrastructure.Persistence;

public sealed class BaseDeDatosMemoria : IDisposable
{
    private readonly SqliteConnection _conexion;

    public BaseDeDatosMemoria()
    {
        _conexion = new SqliteConnection("Data Source=TacomandaDemo;Mode=Memory;Cache=Shared");
        _conexion.Open();
    }

    public void Configurar(DbContextOptionsBuilder options)
    {
        options.UseSqlite(_conexion.ConnectionString);
    }

    public void Dispose()
    {
        _conexion.Dispose();
    }
}
