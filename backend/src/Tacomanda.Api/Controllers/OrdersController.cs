using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Tacomanda.Application;

namespace Tacomanda.Api.Controllers;

[ApiController, Authorize(Roles = RoleNames.Waiter), Route("api")]
public sealed class OrdersController(
    IQueryHandler<ListTablesQuery, IReadOnlyList<TableDto>> tables,
    ICommandHandler<CreateOrderCommand, OrderDto> create) : ControllerBase
{
    public sealed record CreateOrderRequest(
        Guid TableId,
        IReadOnlyList<OrderItemInput> Items);

    [HttpGet("tables")]
    public Task<IReadOnlyList<TableDto>> GetTables(CancellationToken ct) =>
        tables.Handle(new ListTablesQuery(), ct);

    [HttpPost("orders")]
    public async Task<ActionResult<OrderDto>> Post(
        CreateOrderRequest request,
        CancellationToken ct)
    {
        var waiterId = Guid.Parse(
            User.FindFirstValue(ClaimTypes.NameIdentifier)
            ?? throw new UnauthorizedAccessException("Missing user id."));

        var result = await create.Handle(
            new CreateOrderCommand(request.TableId, waiterId, request.Items),
            ct);

        return StatusCode(StatusCodes.Status201Created, result);
    }
}
