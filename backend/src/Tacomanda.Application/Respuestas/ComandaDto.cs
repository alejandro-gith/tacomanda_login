namespace Tacomanda.Application.Respuestas;

public sealed record ComandaDto(
    int Id, int MesaId, int MeseroId, string Estado,
    DateTimeOffset FechaCreacion, IReadOnlyList<DetalleComandaDto> Detalles, decimal Total,
    string? FormaPago, decimal? MontoPagado, DateTimeOffset? FechaCobro,
    DateOnly FechaOperativa, int NumeroDiario, decimal PorcentajePropina,
    decimal Propina, decimal TotalConPropina);
