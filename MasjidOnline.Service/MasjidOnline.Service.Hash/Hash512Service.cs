using System;
using System.Security.Cryptography;
using System.Text;
using MasjidOnline.Service.Hash.Interface;

namespace MasjidOnline.Service.Hash;

public class Hash512Service : IHash512Service
{
    private readonly Random _random = new();

    public byte[] RandomDigestBytes
    {
        get
        {
            var number = _random.NextInt64();

            var bytes = BitConverter.GetBytes(number);

            return SHA512.HashData(bytes);
        }
    }

    public string RandomDigestBase64String => Convert.ToBase64String(RandomDigestBytes);

    public string RandomDigestHexString => Convert.ToHexString(RandomDigestBytes);

    public byte[] Hash(byte[] bytes)
    {
        return SHA512.HashData(bytes);
    }

    public byte[] Hash(string text)
    {
        var bytes = UTF8Encoding.UTF8.GetBytes(text);

        return SHA512.HashData(bytes);
    }
}
