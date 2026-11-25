using MediatR;

namespace Tacomanda.Application.EliminarPlatillo;

public sealed record EliminarPlatilloCommand(int Id) : IRequest<int>;
