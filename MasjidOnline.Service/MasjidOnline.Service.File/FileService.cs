using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Threading.Tasks;
using MasjidOnline.Library.Exceptions;
using MasjidOnline.Service.File.Interface;

namespace MasjidOnline.Service.File;

public class FileService : IFileService
{
    private readonly FileStreamOptions _fileStreamOptions = new()
    {
        Access = FileAccess.Write,
        Mode = FileMode.Create,
        Options = FileOptions.SequentialScan,
        Share = FileShare.None,
    };

    public async Task CreateAsync(Stream stream, string path)
    {
        if (stream.Length > 1048576L) throw new InputInvalidException($"Stream length: {stream.Length}");

        _fileStreamOptions.PreallocationSize = stream.Length;

        using var fileStream = new FileStream(path, _fileStreamOptions);

        await stream.CopyToAsync(fileStream);

        await fileStream.FlushAsync();

        fileStream.Close();
    }

    public void Initialize(IEnumerable<string> createDirectories)
    {
        foreach (var createDirectory in createDirectories)
        {
            if (!Directory.Exists(createDirectory))
            {
                Debug.WriteLine($"Creating directory: {createDirectory}");

                Directory.CreateDirectory(createDirectory);
            }
        }
    }
}
