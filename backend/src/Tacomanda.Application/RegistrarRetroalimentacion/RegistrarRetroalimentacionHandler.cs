using MediatR;
using Tacomanda.Application.Seguridad;
using Tacomanda.Domain.Interfaces;
using RetroalimentacionEntidad = Tacomanda.Domain.Retroalimentacion.Retroalimentacion;

namespace Tacomanda.Application.RegistrarRetroalimentacion;

public sealed class RegistrarRetroalimentacionHandler : IRequestHandler<RegistrarRetroalimentacionCommand, RetroalimentacionDto>
{
    private readonly IRetroalimentacionRepository _repository;
    private readonly IUsuarioActual _usuario;
    private readonly IUnidadDeTrabajo _unidad;
    public RegistrarRetroalimentacionHandler(IRetroalimentacionRepository repository, IUsuarioActual usuario, IUnidadDeTrabajo unidad)
    { _repository = repository; _usuario = usuario; _unidad = unidad; }

    public async Task<RetroalimentacionDto> Handle(RegistrarRetroalimentacionCommand command, CancellationToken ct)
    {
        RetroalimentacionEntidad registro = new(_usuario.ObtenerId(), (byte)command.Calificacion, command.Comentario.Trim());
        _repository.Agregar(registro);
        await _unidad.ConfirmarAsync(ct);
        return new RetroalimentacionDto(registro.Id, registro.FechaHora, registro.Calificacion);
    }
}
