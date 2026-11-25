using Tacomanda.Domain.Excepciones;
using Tacomanda.Domain.Mesas;

namespace Tacomanda.Domain.Comandas;

public sealed class Comanda
{
    private readonly List<DetalleComanda> _detalles = new();

    private Comanda() { }

    public Comanda(Mesa mesa, int meseroId, IEnumerable<DetalleComanda> detalles)
    {
        if (meseroId <= 0 || !mesa.Disponible)
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

        if (Total > 999999.99m)
        {
            throw new ReglaDeNegocioException("El total excede el límite permitido.");
        }

        Id = 0;
        MesaId = mesa.Id;
        MeseroId = meseroId;
        Estado = OrderStatus.Pendiente;
        FechaCreacion = DateTimeOffset.UtcNow;
    }

    public int Id { get; private set; }
    public DateOnly FechaOperativa { get; private set; }
    public int NumeroDiario { get; private set; }
    public int MesaId { get; private set; }
    public int MeseroId { get; private set; }
    public OrderStatus Estado { get; private set; }
    public DateTimeOffset FechaCreacion { get; private set; }
    public string? FormaPago { get; private set; }
    public decimal? MontoPagado { get; private set; }
    public decimal PorcentajePropina { get; private set; }
    public decimal Propina { get; private set; }
    public DateTimeOffset? FechaCobro { get; private set; }
    public int Version { get; private set; }

    public void CambiarEstado(OrderStatus nuevoEstado)
    {
        if ((Estado == OrderStatus.Pendiente && nuevoEstado != OrderStatus.EnPreparacion) ||
            (Estado == OrderStatus.EnPreparacion && nuevoEstado != OrderStatus.Lista) ||
            Estado == OrderStatus.Lista || Estado == OrderStatus.Cobrada)
        {
            throw new ReglaDeNegocioException("Transición de estado no permitida.");
        }
        Estado = nuevoEstado;
        Version++;
    }

    public void Editar(IEnumerable<DetalleComanda> detalles)
    {
        if (Estado != OrderStatus.Pendiente)
        {
            throw new ReglaDeNegocioException("Solo se editan comandas pendientes.");
        }
        List<DetalleComanda> nuevos = detalles.ToList();
        if (nuevos.Count is < 1 or > 100 || nuevos.Select(d => d.PlatilloId).Distinct().Count() != nuevos.Count ||
            nuevos.Sum(d => d.Subtotal) > 999999.99m)
        {
            throw new ReglaDeNegocioException("Detalles de comanda inválidos.");
        }
        _detalles.Clear();
        _detalles.AddRange(nuevos);
        Version++;
    }

    public void AsignarNumeroDiario(DateOnly fechaOperativa, int numero)
    {
        if (Id != 0 || NumeroDiario != 0 || numero < 1)
            throw new ReglaDeNegocioException("El folio diario no se puede asignar.");
        FechaOperativa = fechaOperativa;
        NumeroDiario = numero;
    }

    public void Cobrar(string formaPago, decimal monto, decimal porcentajePropina)
    {
        if (Estado != OrderStatus.Lista || (porcentajePropina != 0 && porcentajePropina < 15) ||
            porcentajePropina > 100 || porcentajePropina < 0 ||
            decimal.Round(porcentajePropina, 2) != porcentajePropina)
        {
            throw new ReglaDeNegocioException("No se puede cobrar esta comanda.");
        }
        decimal propina = decimal.Round(Total * porcentajePropina / 100, 2, MidpointRounding.AwayFromZero);
        if (monto < Total + propina || monto > 999999.99m ||
            (formaPago == "Tarjeta" && monto != Total + propina))
            throw new ReglaDeNegocioException("El monto recibido no cubre el total con propina.");
        FormaPago = formaPago;
        MontoPagado = monto;
        PorcentajePropina = porcentajePropina;
        Propina = propina;
        FechaCobro = DateTimeOffset.UtcNow;
        Estado = OrderStatus.Cobrada;
        Version++;
    }

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

    public decimal TotalConPropina => Total + Propina;
}
