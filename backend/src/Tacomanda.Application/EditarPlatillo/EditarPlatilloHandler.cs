using AutoMapper;
using MediatR;
using Tacomanda.Application.ConsultarPlatillo;
using Tacomanda.Domain.Interfaces;
using Tacomanda.Domain.Platillos;

namespace Tacomanda.Application.EditarPlatillo;

public sealed class EditarPlatilloHandler : IRequestHandler<EditarPlatilloCommand, PlatilloDto>
{
    private readonly IPlatilloRepository _platillos;
    private readonly IUnidadDeTrabajo _unidadDeTrabajo;
    private readonly IMapper _mapper;

    public EditarPlatilloHandler(IPlatilloRepository platillos, IUnidadDeTrabajo unidadDeTrabajo, IMapper mapper)
    {
        _platillos = platillos;
        _unidadDeTrabajo = unidadDeTrabajo;
        _mapper = mapper;
    }

    public async Task<PlatilloDto> Handle(EditarPlatilloCommand command, CancellationToken cancellationToken)
    {
        Platillo platillo = await _platillos.ObtenerAsync(command.Id, cancellationToken)
            ?? throw new KeyNotFoundException("El platillo no existe.");
        platillo.Editar(command.Nombre.Trim(), command.Categoria.Trim(), command.Descripcion.Trim(),
            command.Precio, command.Emoji.Trim());
        await _unidadDeTrabajo.ConfirmarAsync(cancellationToken);
        return _mapper.Map<PlatilloDto>(platillo);
    }
}
