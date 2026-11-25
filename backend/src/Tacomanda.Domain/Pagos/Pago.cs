using Tacomanda.Domain.Excepciones;

namespace Tacomanda.Domain.Pagos;

public sealed class Pago
{
    private Pago() { }
    public Pago(int comandaId, int empleadoId, string forma, decimal monto, decimal total, decimal propina)
    {
        if (comandaId <= 0 || empleadoId <= 0 || monto < total + propina || total <= 0 || propina < 0 ||
            monto > 999999.99m || (forma == "Tarjeta" && monto != total + propina) ||
            forma is not ("Efectivo" or "Tarjeta"))
            throw new ReglaDeNegocioException("Datos de pago inválidos.");
        Id = 0;
        ComandaId = comandaId;
        EmpleadoId = empleadoId;
        Forma = forma;
        Monto = monto;
        Propina = propina;
        Cambio = monto - total - propina;
        TipoPedido = "mesa";
        Fecha = DateTimeOffset.UtcNow;
    }
    public int Id { get; private set; }
    public int ComandaId { get; private set; }
    public int EmpleadoId { get; private set; }
    public string Forma { get; private set; } = "";
    public decimal Monto { get; private set; }
    public decimal Cambio { get; private set; }
    public decimal Propina { get; private set; }
    public string TipoPedido { get; private set; } = "mesa";
    public DateTimeOffset Fecha { get; private set; }
}
