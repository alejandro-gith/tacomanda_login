namespace Tacomanda.Application.CrearComanda;

public sealed record DetalleComandaInput(Guid PlatilloId, int Cantidad, string Observaciones);
