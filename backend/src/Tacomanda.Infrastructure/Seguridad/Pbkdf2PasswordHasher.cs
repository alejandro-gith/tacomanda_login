using System.Security.Cryptography;
using Tacomanda.Application.Seguridad;

namespace Tacomanda.Infrastructure.Seguridad;

public sealed class Pbkdf2PasswordHasher : IPasswordHasher, IPasswordEncoder
{
    private const int Iteraciones = 100000;

    public string Codificar(string password)
    {
        byte[] salt = RandomNumberGenerator.GetBytes(16);
        byte[] hash = Rfc2898DeriveBytes.Pbkdf2(
            password, salt, Iteraciones, HashAlgorithmName.SHA256, 32);
        return Convert.ToBase64String(salt) + "." + Convert.ToBase64String(hash);
    }

    public bool Verificar(string password, string hash)
    {
        try
        {
            string[] partes = hash.Split('.');
            if (partes.Length != 2)
            {
                return false;
            }

            byte[] salt = Convert.FromBase64String(partes[0]);
            byte[] esperado = Convert.FromBase64String(partes[1]);
            if (salt.Length != 16 || esperado.Length != 32)
            {
                return false;
            }

            byte[] actual = Rfc2898DeriveBytes.Pbkdf2(
                password, salt, Iteraciones, HashAlgorithmName.SHA256, 32);
            return CryptographicOperations.FixedTimeEquals(actual, esperado);
        }
        catch (FormatException)
        {
            return false;
        }
    }
}
