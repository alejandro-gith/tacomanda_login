namespace Tacomanda.Application.Respuestas;

public sealed record DetalleComandaDto(
    int PlatilloId, string Nombre, decimal PrecioUnitario,
    int Cantidad, string Observaciones, decimal Subtotal);
