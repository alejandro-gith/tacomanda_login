namespace Tacomanda.Application.Validacion;

public interface IValidator<in T>
{
    void Validar(T solicitud);
}
