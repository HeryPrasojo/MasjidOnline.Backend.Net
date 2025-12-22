using System;

namespace MasjidOnline.Service.Cryptography.Interface;

public interface IEncryption256kService
{
    int OverHeadSize { get; }

    byte[]? Decrypt(ReadOnlySpan<byte> bytes);
    byte[] Encrypt(ReadOnlySpan<byte> bytes);
}
