using MediatR;
using Tacomanda.Application.ConsultarPlatillo;

namespace Tacomanda.Application.EditarPlatillo;

public sealed record EditarPlatilloCommand(Guid Id, string Nombre, string Categoria, string Descripcion, decimal Precio, string Emoji)
    : IRequest<PlatilloDto>;
