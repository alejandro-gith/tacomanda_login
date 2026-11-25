namespace Tacomanda.Application.RegistrarRetroalimentacion;

public sealed record RetroalimentacionDto(int Id, DateTimeOffset FechaHora, int Calificacion);
