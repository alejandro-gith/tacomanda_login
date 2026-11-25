namespace Tacomanda.Application.ConsultarCaja;

public interface IResumenCajaReader
{
    Task<decimal> LeerTotalPendienteAsync(CancellationToken cancellationToken);
}
