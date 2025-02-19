using System;
using System.Security.Cryptography;
using System.Text;
using MasjidOnline.Service.Hash.Interface;

namespace MasjidOnline.Service.Hash;

public class Hash128Service : IHash128Service
{
    public byte[] Hash(string text)
    {
        var bytes = Encoding.UTF8.GetBytes(text);

        if (Shake128.IsSupported) return Shake128.HashData(bytes.AsSpan(), 128);

        return MD5.HashData(bytes.AsSpan());
    }
}
