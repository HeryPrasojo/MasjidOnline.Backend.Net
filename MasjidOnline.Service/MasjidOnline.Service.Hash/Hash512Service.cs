using System;
using System.Security.Cryptography;
using System.Text;
using MasjidOnline.Service.Hash.Interface;

namespace MasjidOnline.Service.Hash;

public class Hash512Service : IHash512Service
{
    public byte[] RandomByteArray => RandomNumberGenerator.GetBytes(64);

    public byte[] Hash(string text)
    {
        var bytes = Encoding.UTF8.GetBytes(text);

        return SHA512.HashData(bytes.AsSpan());
    }
}
