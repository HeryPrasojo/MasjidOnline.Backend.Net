using System.Threading.Tasks;
using MasjidOnline.Data.Interface;
using Microsoft.EntityFrameworkCore;

namespace MasjidOnline.Data.EntityFramework;

public abstract class DataWithoutAudit(DbContext _dbContext) : Data(_dbContext), IData, IDataWithoutAudit
{
    public async Task SaveAsync()
    {
        await _dbContext.SaveChangesAsync();
    }
}
