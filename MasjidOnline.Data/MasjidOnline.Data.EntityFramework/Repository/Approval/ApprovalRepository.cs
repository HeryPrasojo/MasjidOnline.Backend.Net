using System.Threading.Tasks;
using MasjidOnline.Data.Interface.Repository.Approval;
using Microsoft.EntityFrameworkCore;

namespace MasjidOnline.Data.EntityFramework.Repository.Approval;

public class ApprovalRepository(DbContext _dbContext) : IApprovalRepository
{
    private readonly DbSet<Entity.Approval.Approval> _dbSet = _dbContext.Set<Entity.Approval.Approval>();

    public async Task AddAsync(Entity.Approval.Approval approval)
    {
        await _dbSet.AddAsync(approval);
    }

    public async Task<int> GetMaxIdAsync()
    {
        return await _dbSet.MaxAsync(e => (int?)e.Id) ?? 0;
    }
}
