namespace Tacomanda.Application;

public sealed record AvailableUserDto(
    Guid Id,
    string DisplayName,
    string Role);
