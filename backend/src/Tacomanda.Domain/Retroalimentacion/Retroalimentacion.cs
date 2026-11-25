using Tacomanda.Domain.Excepciones;

namespace Tacomanda.Domain.Retroalimentacion;

public sealed class Retroalimentacion
{
    private Retroalimentacion() { }

    public Retroalimentacion(int empleadoId, byte calificacion, string comentario)
    {
        if (empleadoId <= 0 || calificacion is < 1 or > 5 || comentario.Length > 2000)
            throw new ReglaDeNegocioException("Retroalimentación inválida.");
        EmpleadoId = empleadoId;
        Calificacion = calificacion;
        Comentario = comentario;
        FechaHora = DateTimeOffset.UtcNow;
    }

    public int Id { get; private set; }
    public int EmpleadoId { get; private set; }
    public byte Calificacion { get; private set; }
    public string Comentario { get; private set; } = "";
    public DateTimeOffset FechaHora { get; private set; }
}
