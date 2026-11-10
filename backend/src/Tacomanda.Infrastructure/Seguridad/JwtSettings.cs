using System.Security.Cryptography;

namespace Tacomanda.Infrastructure.Seguridad;

public sealed class JwtSettings
{
    private readonly byte[] _signingKey;

    public JwtSettings(string issuer, string audience)
    {
        Issuer = issuer;
        Audience = audience;
        _signingKey = RandomNumberGenerator.GetBytes(32);
    }

    public string Issuer { get; }
    public string Audience { get; }
    public byte[] SigningKey
    {
        get { return (byte[])_signingKey.Clone(); }
    }
}
