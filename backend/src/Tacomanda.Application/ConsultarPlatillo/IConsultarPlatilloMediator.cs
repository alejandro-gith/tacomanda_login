namespace Tacomanda.Application.ConsultarPlatillo;

public interface IConsultarPlatilloMediator
{
    Task<IReadOnlyList<PlatilloDto>> EnviarAsync(ConsultarPlatilloQuery solicitud, CancellationToken cancellationToken);
}
