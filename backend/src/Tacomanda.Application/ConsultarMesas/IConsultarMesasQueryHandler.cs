namespace Tacomanda.Application.ConsultarMesas;

public interface IConsultarMesasQueryHandler
{
    Task<IReadOnlyList<MesaDto>> Handle(ConsultarMesasQuery solicitud, CancellationToken cancellationToken);
}
