namespace MasjidOnline.Service.Hash512.Interface;

public interface IHash512Service
{
    byte[] RandomDigestBytes { get; }
    string RandomDigestBase64String { get; }
    string RandomDigestHexString { get; }

    byte[] Hash(byte[] bytes);
    byte[] Hash(string text);
}
