using System;

namespace MasjidOnline.Service.Hash.Interface;

public interface IHash512Service
{
    ReadOnlySpan<byte> RandomDigestByteSpan { get; }
    string RandomDigestBase64String { get; }
    string RandomDigestHexString { get; }
    byte[] RandomDigestByteArray { get; }

    //ReadOnlySpan<byte> Hash(ReadOnlySpan<byte> bytes);
    byte[] Hash(string text);
}
