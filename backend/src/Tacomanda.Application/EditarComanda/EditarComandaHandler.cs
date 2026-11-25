using AutoMapper;
using MediatR;
using Tacomanda.Application.CrearComanda;
using Tacomanda.Application.Respuestas;
using Tacomanda.Application.Seguridad;
using Tacomanda.Domain.Comandas;
using Tacomanda.Domain.Excepciones;
using Tacomanda.Domain.Interfaces;
using Tacomanda.Domain.Platillos;

namespace Tacomanda.Application.EditarComanda;

public sealed class EditarComandaHandler : IRequestHandler<EditarComandaCommand, ComandaDto>
{
    private readonly IComandaRepository _comandas;
    private readonly IPlatilloRepository _platillos;
    private readonly IUsuarioActual _usuario;
    private readonly IUnidadDeTrabajo _unidad;
    private readonly IMapper _mapper;
    public EditarComandaHandler(IComandaRepository comandas, IPlatilloRepository platillos,
        IUsuarioActual usuario, IUnidadDeTrabajo unidad, IMapper mapper)
    { _comandas = comandas; _platillos = platillos; _usuario = usuario; _unidad = unidad; _mapper = mapper; }
    public async Task<ComandaDto> Handle(EditarComandaCommand command, CancellationToken ct)
    {
        Comanda comanda = await _comandas.ObtenerAsync(command.Id, ct)
            ?? throw new KeyNotFoundException("Comanda inexistente.");
        if (comanda.MeseroId != _usuario.ObtenerId()) throw new UnauthorizedAccessException("La comanda no pertenece al mesero.");
        if (comanda.Estado != OrderStatus.Pendiente) throw new ReglaDeNegocioException("La comanda ya está en preparación.");
        List<DetalleComanda> detalles = new();
        foreach (DetalleComandaInput input in command.Detalles)
        {
            Platillo platillo = await _platillos.ObtenerAsync(input.PlatilloId, ct)
                ?? throw new KeyNotFoundException("Platillo inexistente.");
            if (!platillo.Activo) throw new ReglaDeNegocioException("Platillo desactivado.");
            detalles.Add(new DetalleComanda(platillo.Id, platillo.Nombre, platillo.Precio, input.Cantidad, input.Observaciones));
        }
        comanda.Editar(detalles);
        await _unidad.ConfirmarAsync(ct);
        return _mapper.Map<ComandaDto>(comanda);
    }
}
