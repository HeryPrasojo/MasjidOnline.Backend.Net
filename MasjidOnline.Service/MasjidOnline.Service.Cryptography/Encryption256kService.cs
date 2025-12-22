using System;
using System.Buffers.Binary;
using System.Security.Cryptography;
using MasjidOnline.Service.Cryptography.Interface;
using MasjidOnline.Service.Cryptography.Interface.Model;
using MasjidOnline.Service.Hash.Interface;
using Microsoft.Extensions.Options;

namespace MasjidOnline.Service.Cryptography;

public class Encryption256kService(IOptionsMonitor<CryptographyOptions> _options, IHash256Service _hash256Service) : IEncryption256kService
{
    private static readonly int _associatedDataSize = sizeof(short);
    private static readonly int _nonceSize = 12;
    private static readonly int _tagSize = AesGcm.TagByteSizes.MaxSize;

    private readonly byte[] _key = _hash256Service.Hash(Convert.FromBase64String(_options.CurrentValue.Key256Base64));

    public int OverHeadSize => _associatedDataSize + _nonceSize + _tagSize;

    public byte[]? Decrypt(ReadOnlySpan<byte> bytes)
    {
        var nonce = bytes[.._nonceSize];

        var chiperTextSize = bytes.Length - _nonceSize - _tagSize - _associatedDataSize;

        var cipherText = bytes.Slice(_nonceSize, chiperTextSize);

        var tag = bytes.Slice(_nonceSize + chiperTextSize, _tagSize);

        var plainText = new byte[chiperTextSize];

        var associatedData = bytes[(_nonceSize + chiperTextSize + _tagSize)..];

        using var aesGcm = new AesGcm(_key.AsSpan(), _tagSize);

        aesGcm.Decrypt(nonce, cipherText, tag, plainText, associatedData);

        return plainText;
    }

    public byte[] Encrypt(ReadOnlySpan<byte> bytes)
    {
        var bytesLength = bytes.Length;

        var buffer = new byte[_nonceSize + bytesLength + _tagSize + _associatedDataSize];

        var bufferSpan = buffer.AsSpan();

        var nonce = bufferSpan[.._nonceSize];

        RandomNumberGenerator.Fill(nonce);

        var ciphertext = bufferSpan.Slice(_nonceSize, bytesLength);

        var tag = bufferSpan.Slice(_nonceSize + bytesLength, _tagSize);

        var associatedData = bufferSpan[(_nonceSize + bytesLength + _tagSize)..];

        BinaryPrimitives.WriteInt16LittleEndian(associatedData, (short)bytesLength);

        using var aesGcm = new AesGcm(_key.AsSpan(), _tagSize);

        aesGcm.Encrypt(nonce, bytes, ciphertext, tag, associatedData);

        return buffer;
    }
}
