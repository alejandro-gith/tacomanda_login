using Tacomanda.Domain;

namespace Tacomanda.Application;

public sealed class ListTablesHandler(ITableRepository tables)
    : IQueryHandler<ListTablesQuery, IReadOnlyList<TableDto>>
{
    public async Task<IReadOnlyList<TableDto>> Handle(
        ListTablesQuery query,
        CancellationToken ct)
    {
        var tableList = await tables.ListAsync(ct);
        return tableList
            .Select(table => new TableDto(
                table.Id,
                table.Name,
                table.Status == TableStatus.Available ? "Disponible" : "Ocupada"))
            .ToArray();
    }
}
