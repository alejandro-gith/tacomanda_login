using Tacomanda.Domain.Excepciones;

namespace Tacomanda.Domain.Pagos;

public sealed class PoliticaEfectivo : IPoliticaDePago
{
    public string Forma => "Efectivo";
    public void Validar(decimal total, decimal monto)
    {
        if (monto < total) throw new ReglaDeNegocioException("El efectivo no cubre el total.");
    }
}
