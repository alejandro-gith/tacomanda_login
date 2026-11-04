using Tacomanda.Domain.Comandas;

namespace Tacomanda.Application.Respuestas;

public sealed class ComandaDtoMapper : IComandaDtoMapper
{
    public ComandaDto Convertir(Comanda comanda)
    {
        List<DetalleComandaDto> detalles = new();

        foreach (DetalleComanda detalle in comanda.Detalles)
        {
            detalles.Add(new DetalleComandaDto(
                detalle.PlatilloId, detalle.Nombre, detalle.PrecioUnitario,
                detalle.Cantidad, detalle.Observaciones, detalle.Subtotal));
        }

        return new ComandaDto(
            comanda.Id, comanda.MesaId, comanda.MeseroId, comanda.Estado.ToString(),
            comanda.FechaCreacion, detalles.AsReadOnly(), comanda.Total);
    }
}
