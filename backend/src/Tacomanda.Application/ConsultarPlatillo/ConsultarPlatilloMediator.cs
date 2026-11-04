namespace Tacomanda.Application.ConsultarPlatillo;

public sealed class ConsultarPlatilloMediator : IConsultarPlatilloMediator
{
    private readonly IConsultarPlatilloQueryHandler _handler;

    public ConsultarPlatilloMediator(
        IConsultarPlatilloQueryHandler handler)
    {
        _handler = handler;
    }

    public async Task<IReadOnlyList<PlatilloDto>> EnviarAsync(
        ConsultarPlatilloQuery solicitud,
        CancellationToken cancellationToken)
    {
        return await _handler.Handle(solicitud, cancellationToken);
    }
}
