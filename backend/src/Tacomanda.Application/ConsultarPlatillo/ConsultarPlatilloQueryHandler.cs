using Tacomanda.Application.Validacion;
using Tacomanda.Domain.Platillos;

namespace Tacomanda.Application.ConsultarPlatillo;

public sealed class ConsultarPlatilloQueryHandler
    : IConsultarPlatilloQueryHandler
{
    private readonly IPlatilloReader _reader;

    public ConsultarPlatilloQueryHandler(IPlatilloReader reader)
    {
        _reader = reader;
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

            resultado.Add(new PlatilloDto(
                platillo.Id, platillo.Nombre, platillo.Categoria,
                platillo.Descripcion, platillo.Precio, platillo.Emoji));
        }

        return resultado.AsReadOnly();
    }
}
