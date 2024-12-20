﻿using System;
using System.Security.Cryptography;
using MasjidOnline.Service.Hash512.Interface;

namespace MasjidOnline.Service.Hash512;

public class Hash512Service : IHash512Service
{
    private readonly Random _random = new();

    public string HashRandom()
    {
        var number = _random.NextInt64();

        var bytes = BitConverter.GetBytes(number);

        var digest = SHA512.HashData(bytes);

        return Convert.ToBase64String(digest);
    }
}
