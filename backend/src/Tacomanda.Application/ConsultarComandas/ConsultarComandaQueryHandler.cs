using AutoMapper;
using MediatR;
using Tacomanda.Application.Respuestas;
using Tacomanda.Application.Seguridad;
using Tacomanda.Application.Validacion;
using Tacomanda.Domain.Comandas;
using Tacomanda.Domain.Interfaces;

namespace Tacomanda.Application.ConsultarComandas;

public sealed class ConsultarComandaQueryHandler : IRequestHandler<ConsultarComandaQuery, ComandaDto>
{
    private readonly IComandaReader _reader;
    private readonly IUsuarioActual _usuario;
    private readonly IMapper _mapper;
    public ConsultarComandaQueryHandler(IComandaReader reader, IUsuarioActual usuario, IMapper mapper)
    { _reader = reader; _usuario = usuario; _mapper = mapper; }
    public async Task<ComandaDto> Handle(ConsultarComandaQuery query, CancellationToken ct)
    {
        if (query.Id <= 0) throw new ValidacionException("Identificador inválido.");
        Comanda comanda = await _reader.ObtenerAsync(query.Id, ct)
            ?? throw new KeyNotFoundException("Comanda inexistente.");
        string rol = _usuario.ObtenerRol();
        if (rol == "Mesero" && comanda.MeseroId != _usuario.ObtenerId())
            throw new KeyNotFoundException("Comanda inexistente.");
        if (rol == "Cocinero" && comanda.Estado == OrderStatus.Cobrada)
            throw new KeyNotFoundException("Comanda inexistente.");
        return _mapper.Map<ComandaDto>(comanda);
    }
}
