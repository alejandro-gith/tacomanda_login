namespace Tacomanda.Application.Seguridad;

public interface IPasswordHasher
{
    bool Verificar(string password, string hash);
}
