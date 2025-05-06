
namespace MasjidOnline.Service.File.Interface;

public interface IFileService
{
    Task CreateAsync(Stream stream, string path);
}
