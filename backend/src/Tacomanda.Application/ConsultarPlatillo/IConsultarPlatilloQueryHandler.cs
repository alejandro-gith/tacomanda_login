namespace Tacomanda.Application.ConsultarPlatillo;

public interface IConsultarPlatilloQueryHandler
{
    Task<IReadOnlyList<PlatilloDto>> Handle(ConsultarPlatilloQuery solicitud, CancellationToken cancellationToken);
}
