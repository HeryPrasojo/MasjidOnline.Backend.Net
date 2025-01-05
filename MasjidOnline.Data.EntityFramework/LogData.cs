using System.Threading.Tasks;
using MasjidOnline.Data.Interface;

namespace MasjidOnline.Data.EntityFramework;

public class LogData(LogDataContext _dataContext) : ILogData
{

    public async Task<int> SaveAsync()
    {
        return await _dataContext.SaveChangesAsync();
    }
}
