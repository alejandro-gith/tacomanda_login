namespace Tacomanda.Application.ConsultarMesas;

public interface IConsultarMesasMediator
{
    Task<IReadOnlyList<MesaDto>> EnviarAsync(ConsultarMesasQuery solicitud, CancellationToken cancellationToken);
}
