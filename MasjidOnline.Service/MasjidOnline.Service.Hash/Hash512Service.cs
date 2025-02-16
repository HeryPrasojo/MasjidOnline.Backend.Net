using System;
using System.Security.Cryptography;
using System.Text;
using MasjidOnline.Service.Hash.Interface;

namespace MasjidOnline.Service.Hash;

public class Hash512Service : IHash512Service
{
    private readonly Random _random = new();

    public byte[] RandomDigestByteArray
    {
        get
        {
            var number = _random.NextInt64();

            var bytes = BitConverter.GetBytes(number);

            return SHA512.HashData(bytes.AsSpan());
        }
    }

    public ReadOnlySpan<byte> RandomDigestByteSpan
    {
        get
        {
            var number = _random.NextInt64();

            var bytes = BitConverter.GetBytes(number);

            return SHA512.HashData(bytes.AsSpan())
                .AsSpan();
        }
    }

    public string RandomDigestBase64String => Convert.ToBase64String(RandomDigestByteSpan);

    public string RandomDigestHexString => Convert.ToHexString(RandomDigestByteSpan);

    //public ReadOnlySpan<byte> Hash(ReadOnlySpan<byte> bytes)
    //{
    //    return SHA512.HashData(bytes)
    //        .AsSpan();
    //}

    public byte[] Hash(string text)
    {
        var bytes = Encoding.UTF8.GetBytes(text);

        return SHA512.HashData(bytes.AsSpan());
    }
}
