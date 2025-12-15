namespace MasjidOnline.Service.Cryptography.Interface;

public interface ICryptographyService
{
    byte[] RandomBytes64 { get; }
}
