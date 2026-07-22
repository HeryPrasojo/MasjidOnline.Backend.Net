using System.Threading.Tasks;
using MasjidOnline.Data.Interface.Repository.Approval;
using MasjidOnline.Entity.Approval;
using Microsoft.EntityFrameworkCore;

namespace MasjidOnline.Data.EntityFramework.Repository.Approval;

public class ApprovalSettingRepository(DbContext _dbContext) : IApprovalSettingRepository
{
    private readonly DbSet<ApprovalSetting> _dbSet = _dbContext.Set<ApprovalSetting>();

    public async Task AddAndSaveAsync(ApprovalSetting approvalSetting)
    {
        await _dbSet.AddAsync(approvalSetting);

        await _dbContext.SaveChangesAsync();
    }
}
