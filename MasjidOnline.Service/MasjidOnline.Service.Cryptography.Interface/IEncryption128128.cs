using System;

namespace MasjidOnline.Service.Cryptography.Interface;

public interface IEncryption128128
{
    byte[] Decrypt(ReadOnlySpan<byte> bytes);
    ReadOnlySpan<byte> Encrypt(ReadOnlySpan<byte> bytes);
}
