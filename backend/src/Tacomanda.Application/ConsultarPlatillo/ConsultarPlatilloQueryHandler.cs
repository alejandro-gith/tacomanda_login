using AutoMapper;
using MediatR;
using Tacomanda.Application.Validacion;
using Tacomanda.Domain.Platillos;

namespace Tacomanda.Application.ConsultarPlatillo;

public sealed class ConsultarPlatilloQueryHandler
    : IRequestHandler<ConsultarPlatilloQuery, IReadOnlyList<PlatilloDto>>
{
    private readonly IPlatilloReader _reader;
    private readonly IMapper _mapper;

    public ConsultarPlatilloQueryHandler(IPlatilloReader reader, IMapper mapper)
    {
        _reader = reader;
        _mapper = mapper;
    }

    public async Task<IReadOnlyList<PlatilloDto>> Handle(
        ConsultarPlatilloQuery query, CancellationToken cancellationToken)
    {
        if (query.Pagina < 1 || query.TamanoPagina < 1 || query.TamanoPagina > 100)
        {
            throw new ValidacionException("Paginación inválida.");
        }

        IReadOnlyList<Platillo> platillos = await _reader.LeerAsync(cancellationToken);
        List<PlatilloDto> resultado = new();
        long omitir = ((long)query.Pagina - 1) * query.TamanoPagina;
        long indice = 0;

        foreach (Platillo platillo in platillos)
        {
            if (!platillo.Activo ||
                (!string.IsNullOrEmpty(query.Categoria) && platillo.Categoria != query.Categoria))
            {
                continue;
            }

            if (indice++ < omitir || resultado.Count >= query.TamanoPagina)
            {
                continue;
            }

            resultado.Add(_mapper.Map<PlatilloDto>(platillo));
        }

        return resultado.AsReadOnly();
    }
}
