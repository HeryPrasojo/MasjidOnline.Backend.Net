using System;
using System.IO;
using System.Security.Cryptography;
using MasjidOnline.Service.Cryptography.Interface;
using MasjidOnline.Service.Hash.Interface;
using Microsoft.Extensions.Options;

namespace MasjidOnline.Service.Cryptography;

public class Encryption128128Service(IOptionsMonitor<Interface.Model.CryptographyOptions> _options, IHash128Service _hash128Service) : IEncryption128128Service
{
    private readonly byte[] _key = _hash128Service.Hash(_options.CurrentValue.Key128);

    public byte[] Decrypt(ReadOnlySpan<byte> bytes)
    {
        using var aes = Aes.Create();

        //aes.BlockSize = 128;
        aes.IV = bytes[..16].ToArray();
        aes.Key = _key;
        //aes.KeySize = 128; // buggy
        //aes.Mode = CipherMode.CBC;
        aes.Padding = PaddingMode.PKCS7;

        using var cryptoTransform = aes.CreateDecryptor(aes.Key, aes.IV);

        using var inputMemoryStream = new MemoryStream(bytes[16..].ToArray());

        using var cryptoStream = new CryptoStream(inputMemoryStream, cryptoTransform, CryptoStreamMode.Read, true);

        using var outputMemoryStream = new MemoryStream(bytes.Length - 16);

        cryptoStream.CopyTo(outputMemoryStream);

        return outputMemoryStream.ToArray();
    }

    public ReadOnlySpan<byte> Encrypt(ReadOnlySpan<byte> bytes)
    {
        using var ivAes = Aes.Create();

        using var memoryStream = new MemoryStream();

        memoryStream.Write(ivAes.IV.AsSpan());

        using var aes = Aes.Create();

        //aes.BlockSize = 128;
        aes.IV = ivAes.IV;
        aes.Key = _key;
        //aes.KeySize = 128; // buggy
        //aes.Mode = CipherMode.CBC;
        aes.Padding = PaddingMode.PKCS7;

        using var cryptoTransform = aes.CreateEncryptor(aes.Key, aes.IV);

        using var cryptoStream = new CryptoStream(memoryStream, cryptoTransform, CryptoStreamMode.Write, true);

        cryptoStream.Write(bytes);

        cryptoStream.FlushFinalBlock();

        return memoryStream.ToArray();
    }
}
