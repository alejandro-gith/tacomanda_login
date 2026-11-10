using MediatR;
using Tacomanda.Application.ConsultarPlatillo;

namespace Tacomanda.Application.CrearPlatillo;

public sealed record CrearPlatilloCommand(string Nombre, string Categoria, string Descripcion, decimal Precio, string Emoji)
    : IRequest<PlatilloDto>;
