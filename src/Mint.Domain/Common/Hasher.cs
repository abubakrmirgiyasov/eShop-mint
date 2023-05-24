using Microsoft.AspNetCore.Cryptography.KeyDerivation;
using System.Security.Cryptography;

namespace Mint.Domain.Common;

public class Hasher
{
    public byte[] GetSalt()
    {
        byte[] salt = new byte[128 / 8];
        using var random = RandomNumberGenerator.Create();
        random.GetBytes(salt);
        return salt;
    }

    public string GetHash(string password, byte[] salt)
        => Convert.ToBase64String(KeyDerivation.Pbkdf2(
            password: password,
            salt: salt,
            prf: KeyDerivationPrf.HMACSHA1,
            iterationCount: 1000,
            numBytesRequested: 256 / 8));
}
