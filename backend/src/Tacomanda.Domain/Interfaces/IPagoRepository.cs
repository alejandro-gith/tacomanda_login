using Tacomanda.Domain.Pagos;

namespace Tacomanda.Domain.Interfaces;

public interface IPagoRepository
{
    void Agregar(Pago pago);
}
