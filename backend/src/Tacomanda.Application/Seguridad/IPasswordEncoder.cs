namespace Tacomanda.Application.Seguridad;

public interface IPasswordEncoder
{
    string Codificar(string password);
}
