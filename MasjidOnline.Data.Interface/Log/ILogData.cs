using System.Threading.Tasks;

namespace MasjidOnline.Data.Interface.Log;

public interface ILogData
{
    IErrorExceptionRepository ErrorException { get; }

    Task<int> SaveAsync();
}
