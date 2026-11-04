namespace Tacomanda.Application.Respuestas;

public sealed record ComandaDto(
    Guid Id, Guid MesaId, Guid MeseroId, string Estado,
    DateTimeOffset FechaCreacion, IReadOnlyList<DetalleComandaDto> Detalles, decimal Total);
