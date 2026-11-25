using Tacomanda.Application.ConsultarCaja;
using Tacomanda.Domain.Interfaces;

namespace Tacomanda.Infrastructure.Persistence.Readers;

public sealed class ResumenCajaReader : IResumenCajaReader
{
    private readonly ICierresLecturaRepository _repository;
    public ResumenCajaReader(ICierresLecturaRepository repository) { _repository = repository; }
    public Task<decimal> LeerTotalPendienteAsync(CancellationToken ct) =>
        _repository.TotalPendienteAsync(ct);
}
