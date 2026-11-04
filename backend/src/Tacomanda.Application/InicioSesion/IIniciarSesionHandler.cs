namespace Tacomanda.Application.InicioSesion;

public interface IIniciarSesionHandler
{
    Task<SesionDto> Handle(IniciarSesionCommand solicitud, CancellationToken cancellationToken);
}
