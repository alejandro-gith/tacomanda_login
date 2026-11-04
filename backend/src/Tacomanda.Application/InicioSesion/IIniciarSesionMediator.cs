namespace Tacomanda.Application.InicioSesion;

public interface IIniciarSesionMediator
{
    Task<SesionDto> EnviarAsync(IniciarSesionCommand solicitud, CancellationToken cancellationToken);
}
