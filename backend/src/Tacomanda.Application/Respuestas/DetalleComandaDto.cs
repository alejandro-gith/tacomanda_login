namespace Tacomanda.Application.Respuestas;

public sealed record DetalleComandaDto(
    Guid PlatilloId, string Nombre, decimal PrecioUnitario,
    int Cantidad, string Observaciones, decimal Subtotal);
