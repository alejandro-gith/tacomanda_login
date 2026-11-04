using Tacomanda.Domain.Excepciones;

namespace Tacomanda.Domain.Comandas;

public sealed class DetalleComanda
{
    private DetalleComanda() { }

    public DetalleComanda(Guid platilloId, string nombre, decimal precio, int cantidad, string observaciones)
    {
        if (platilloId == Guid.Empty || precio <= 0 || cantidad < 1 || cantidad > 99 ||
            observaciones.Length > 200)
        {
            throw new ReglaDeNegocioException("Detalle de comanda inválido.");
        }

        Id = Guid.NewGuid();
        PlatilloId = platilloId;
        Nombre = nombre;
        PrecioUnitario = precio;
        Cantidad = cantidad;
        Observaciones = observaciones;
    }

    public Guid Id { get; private set; }
    public Guid PlatilloId { get; private set; }
    public string Nombre { get; private set; } = "";
    public decimal PrecioUnitario { get; private set; }
    public int Cantidad { get; private set; }
    public string Observaciones { get; private set; } = "";

    public decimal Subtotal
    {
        get { return PrecioUnitario * Cantidad; }
    }
}
