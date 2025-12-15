using System;

namespace MasjidOnline.Service.Cryptography.Interface;

public interface IEncryption256k128bService
{
    byte[]? Decrypt(ReadOnlySpan<byte> bytes);
    ReadOnlySpan<byte> Encrypt(ReadOnlySpan<byte> bytes);
}
