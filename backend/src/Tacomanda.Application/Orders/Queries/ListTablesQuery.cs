namespace Tacomanda.Application;

public sealed record ListTablesQuery : IQuery<IReadOnlyList<TableDto>>;
