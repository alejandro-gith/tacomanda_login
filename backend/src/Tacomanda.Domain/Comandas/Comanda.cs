using Tacomanda.Domain.Excepciones;
using Tacomanda.Domain.Mesas;

namespace Tacomanda.Domain.Comandas;

public sealed class Comanda
{
    private readonly List<DetalleComanda> _detalles = new();

    private Comanda() { }

    public Comanda(Mesa mesa, Guid meseroId, IEnumerable<DetalleComanda> detalles)
    {
        if (meseroId == Guid.Empty || !mesa.Disponible)
        {
            throw new ReglaDeNegocioException("Mesero o mesa inválidos.");
        }

        foreach (DetalleComanda detalle in detalles)
        {
            _detalles.Add(detalle);
        }

        if (_detalles.Count == 0 || _detalles.Count > 100)
        {
            throw new ReglaDeNegocioException("La comanda requiere entre 1 y 100 detalles.");
        }

        Id = Guid.NewGuid();
        MesaId = mesa.Id;
        MeseroId = meseroId;
        Estado = OrderStatus.Pendiente;
        FechaCreacion = DateTimeOffset.UtcNow;
    }

    public Guid Id { get; private set; }
    public Guid MesaId { get; private set; }
    public Guid MeseroId { get; private set; }
    public OrderStatus Estado { get; private set; }
    public DateTimeOffset FechaCreacion { get; private set; }

    public IReadOnlyCollection<DetalleComanda> Detalles
    {
        get { return _detalles.AsReadOnly(); }
    }

    public decimal Total
    {
        get
        {
            decimal total = 0;
            foreach (DetalleComanda detalle in _detalles)
            {
                total += detalle.Subtotal;
            }
            return total;
        }
    }
}
