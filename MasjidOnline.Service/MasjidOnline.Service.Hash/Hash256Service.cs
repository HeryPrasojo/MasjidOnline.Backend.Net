using System;
using System.Security.Cryptography;
using MasjidOnline.Service.Hash.Interface;

namespace MasjidOnline.Service.Hash;

public class Hash256Service : IHash256Service
{
    public byte[] Hash(Span<byte> bytes)
    {
        return SHA256.HashData(bytes);
    }
}
