using Tacomanda.Domain.Excepciones;

namespace Tacomanda.Domain.Cierres;

public sealed class CierreCaja
{
    private CierreCaja() { }

    public CierreCaja(int empleadoId, decimal totalSistema, decimal totalContado,
        bool huboIncidencias, string comentarios)
    {
        if (empleadoId <= 0 || totalSistema < 0 || totalContado < 0 || comentarios.Length > 2000)
            throw new ReglaDeNegocioException("Datos de cierre inválidos.");
        EmpleadoId = empleadoId;
        TotalSistema = totalSistema;
        TotalContado = totalContado;
        Diferencia = totalContado - totalSistema;
        HuboIncidencias = huboIncidencias;
        Comentarios = comentarios;
        FechaHora = DateTimeOffset.UtcNow;
    }

    public int Id { get; private set; }
    public int EmpleadoId { get; private set; }
    public DateTimeOffset FechaHora { get; private set; }
    public decimal TotalSistema { get; private set; }
    public decimal TotalContado { get; private set; }
    public decimal Diferencia { get; private set; }
    public bool HuboIncidencias { get; private set; }
    public string Comentarios { get; private set; } = "";
}
