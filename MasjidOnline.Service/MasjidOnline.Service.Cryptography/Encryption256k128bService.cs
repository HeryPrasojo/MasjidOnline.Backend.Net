using System;
using System.IO;
using System.Security.Cryptography;
using MasjidOnline.Service.Cryptography.Interface;
using MasjidOnline.Service.Cryptography.Interface.Model;
using MasjidOnline.Service.Hash.Interface;
using Microsoft.Extensions.Options;

namespace MasjidOnline.Service.Cryptography;

public class Encryption256k128bService(IOptionsMonitor<CryptographyOptions> _options, IHash256Service _hash256Service) : IEncryption256k128bService
{
    private readonly byte[] _key = _hash256Service.Hash(Convert.FromBase64String(_options.CurrentValue.Key256Base64));

    // undone change to AesGcm
    private static Aes CreateAes()
    {
        var aes = Aes.Create();

        aes.Mode = CipherMode.CBC;
        aes.Padding = PaddingMode.PKCS7;

        aes.BlockSize = 128;
        aes.KeySize = 256;

        return aes;
    }

    public byte[]? Decrypt(ReadOnlySpan<byte> bytes)
    {
        try
        {
            using var aes = CreateAes();

            aes.IV = bytes[..aes.IV.Length].ToArray();
            aes.Key = _key;

            using var cryptoTransform = aes.CreateDecryptor(aes.Key, aes.IV);

            using var inputMemoryStream = new MemoryStream(bytes[aes.IV.Length..].ToArray());

            using var cryptoStream = new CryptoStream(inputMemoryStream, cryptoTransform, CryptoStreamMode.Read, true);

            using var outputMemoryStream = new MemoryStream(bytes.Length - aes.IV.Length);

            cryptoStream.CopyTo(outputMemoryStream);

            return outputMemoryStream.ToArray();

        }
        catch (CryptographicException)
        {
            return default;
        }
    }

    public ReadOnlySpan<byte> Encrypt(ReadOnlySpan<byte> bytes)
    {
        using var aes = CreateAes();

        aes.Key = _key;

        using var cryptoTransform = aes.CreateEncryptor(aes.Key, aes.IV);

        using var memoryStream = new MemoryStream(aes.IV.Length + bytes.Length);

        memoryStream.Write(aes.IV.AsSpan());

        using var cryptoStream = new CryptoStream(memoryStream, cryptoTransform, CryptoStreamMode.Write, true);

        cryptoStream.Write(bytes);

        cryptoStream.FlushFinalBlock();

        return memoryStream.ToArray();
    }
}
