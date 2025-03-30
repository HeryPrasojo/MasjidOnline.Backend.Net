using System;

namespace MasjidOnline.Service.Cryptography.Interface;

public interface IEncryption128128Service
{
    byte[] Decrypt(ReadOnlySpan<byte> bytes);
    ReadOnlySpan<byte> Encrypt(ReadOnlySpan<byte> bytes);
}
