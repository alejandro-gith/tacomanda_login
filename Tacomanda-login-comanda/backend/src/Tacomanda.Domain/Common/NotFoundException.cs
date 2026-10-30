namespace Tacomanda.Domain;

public sealed class NotFoundException(string message)
    : DomainException(message);
