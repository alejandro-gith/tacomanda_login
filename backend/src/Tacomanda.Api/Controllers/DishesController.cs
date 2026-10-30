using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Tacomanda.Application;

namespace Tacomanda.Api.Controllers;

[ApiController, Authorize(Roles = RoleNames.Waiter), Route("api/dishes")]
public sealed class DishesController(
    IQueryHandler<ListDishesQuery, IReadOnlyList<DishDto>> list) : ControllerBase
{
    [HttpGet]
    public Task<IReadOnlyList<DishDto>> Get(CancellationToken ct) =>
        list.Handle(new ListDishesQuery(true), ct);
}
