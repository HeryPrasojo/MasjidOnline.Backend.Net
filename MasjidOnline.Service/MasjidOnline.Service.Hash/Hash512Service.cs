using System;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using MasjidOnline.Service.Hash.Interface;

namespace MasjidOnline.Service.Hash;

public class Hash512Service : IHash512Service
{
    private readonly Random _random = new();

    public byte[] RandomByteArray => RandomNumberGenerator.GetBytes(64);

    public byte[] RandomDigestByteArray
    {
        get
        {
            var number = _random.NextInt64();

            var bytes = BitConverter.GetBytes(DateTime.Now.Ticks);
            var bytes2 = BitConverter.GetBytes(number);

            var bytes3 = bytes.Concat(bytes2).ToArray();

            return SHA512.HashData(bytes3.AsSpan());
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

    public ReadOnlySpan<byte> Hash(ReadOnlySpan<byte> bytes)
    {
        return SHA512.HashData(bytes)
            .AsSpan();
    }

    public byte[] Hash(string text)
    {
        var bytes = Encoding.UTF8.GetBytes(text);

        return SHA512.HashData(bytes.AsSpan());
    }
}
