namespace Tacomanda.Domain.Pagos;

public interface IPoliticaDePago
{
    string Forma { get; }
    void Validar(decimal total, decimal monto);
}
