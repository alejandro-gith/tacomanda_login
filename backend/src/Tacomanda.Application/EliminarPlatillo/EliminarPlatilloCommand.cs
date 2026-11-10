using MediatR;

namespace Tacomanda.Application.EliminarPlatillo;

public sealed record EliminarPlatilloCommand(Guid Id) : IRequest<Guid>;
