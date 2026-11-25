using Tacomanda.Domain.Excepciones;

namespace Tacomanda.Domain.Pagos;

public sealed class PoliticaTarjeta : IPoliticaDePago
{
    public string Forma => "Tarjeta";
    public void Validar(decimal total, decimal monto)
    {
        if (monto != total) throw new ReglaDeNegocioException("El cobro con tarjeta debe coincidir con el total.");
    }
}
