using MediatR;

namespace Tacomanda.Application.ConsultarCaja;

public sealed class ConsultarCajaQueryHandler : IRequestHandler<ConsultarCajaQuery, ResumenCajaDto>
{
    private readonly IResumenCajaReader _reader;
    public ConsultarCajaQueryHandler(IResumenCajaReader reader) { _reader = reader; }
    public async Task<ResumenCajaDto> Handle(ConsultarCajaQuery query, CancellationToken ct)
    {
        decimal total = await _reader.LeerTotalPendienteAsync(ct);
        return new ResumenCajaDto(total);
    }
}
