using MediatR;

namespace Tacomanda.Application.ConsultarPlatillo;

public sealed record ConsultarPlatilloQuery(
    string? Categoria = null, int Pagina = 1, int TamanoPagina = 100)
    : IRequest<IReadOnlyList<PlatilloDto>>;
