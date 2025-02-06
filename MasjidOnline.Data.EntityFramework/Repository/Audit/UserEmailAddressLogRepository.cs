using System.Threading.Tasks;
using MasjidOnline.Data.EntityFramework.DataContext;
using MasjidOnline.Data.Interface.Repository.Audit;
using MasjidOnline.Entity.Audit;
using Microsoft.EntityFrameworkCore;

namespace MasjidOnline.Data.EntityFramework.Repository.Audit;

public class UserEmailAddressLogRepository(AuditDataContext _auditDataContext) : IUserEmailAddressLogRepository
{
    private readonly DbSet<UserEmailAddressLog> _dbSet = _auditDataContext.Set<UserEmailAddressLog>();


    public async Task<int> GetMaxUserEmailAddressLogIdAsync()
    {
        return await _dbSet.MaxAsync(e => (int?)e.UserEmailAddressLogId) ?? 0;
    }
}
