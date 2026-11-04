namespace Tacomanda.Application.ConsultarMesas;

public sealed class ConsultarMesasMediator : IConsultarMesasMediator
{
    private readonly IConsultarMesasQueryHandler _handler;

    public ConsultarMesasMediator(
        IConsultarMesasQueryHandler handler)
    {
        _handler = handler;
    }

    public async Task<IReadOnlyList<MesaDto>> EnviarAsync(
        ConsultarMesasQuery solicitud,
        CancellationToken cancellationToken)
    {
        return await _handler.Handle(solicitud, cancellationToken);
    }
}
