﻿using System.Security.Cryptography;
using MasjidOnline.Service.Hash512.Interface;

namespace MasjidOnline.Service.Hash512;

public class Hash512Service : IHash512Service
{
    public void hashRandom()
    {
        SHA512.HashDataAsync()
    }
}
