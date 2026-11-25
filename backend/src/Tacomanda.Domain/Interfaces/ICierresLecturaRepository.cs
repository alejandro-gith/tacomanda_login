namespace Tacomanda.Domain.Interfaces;

public interface ICierresLecturaRepository
{
    Task<decimal> TotalPendienteAsync(CancellationToken cancellationToken);
}
