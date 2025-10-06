using System;

namespace MasjidOnline.Service.Cryptography.Interface;

public interface IEncryption128b256kService
{
    byte[]? Decrypt(ReadOnlySpan<byte> bytes);
    ReadOnlySpan<byte> Encrypt(ReadOnlySpan<byte> bytes);
}
