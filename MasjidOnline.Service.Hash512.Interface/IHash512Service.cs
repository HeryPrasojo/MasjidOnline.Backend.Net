﻿namespace MasjidOnline.Service.Hash512.Interface;

public interface IHash512Service
{
    byte[] RandomDigestBytes { get; }
    string RandomDigestBase64String { get; }
}
