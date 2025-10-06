using System;

namespace MasjidOnline.Service.Hash.Interface;

public interface IHash256Service
{
    byte[] Hash(Span<byte> bytes);
}
