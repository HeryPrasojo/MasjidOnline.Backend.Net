using System.Security.Cryptography;
using MasjidOnline.Service.Cryptography.Interface;

namespace MasjidOnline.Service.Cryptography;

public class CryptographyService : ICryptographyService
{
    public byte[] RandomBytes64 => RandomNumberGenerator.GetBytes(64);
}
