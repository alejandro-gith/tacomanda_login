namespace Tacomanda.Application;

public interface IValidator<in TRequest>
{
    void Validate(TRequest request);
}
