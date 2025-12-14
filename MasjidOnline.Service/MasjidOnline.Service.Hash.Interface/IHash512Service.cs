namespace MasjidOnline.Service.Hash.Interface;

public interface IHash512Service
{
    byte[] RandomByteArray { get; }
    byte[] Hash(string text);
}
