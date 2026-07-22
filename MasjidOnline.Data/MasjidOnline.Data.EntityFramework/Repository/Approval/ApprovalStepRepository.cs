using System.Threading.Tasks;
using MasjidOnline.Data.Interface.Repository.Approval;
using Microsoft.EntityFrameworkCore;

namespace MasjidOnline.Data.EntityFramework.Repository.Approval;

public class ApprovalStepRepository(DbContext _dbContext) : IApprovalStepRepository
{
    private readonly DbSet<Entity.Approval.ApprovalStep> _dbSet = _dbContext.Set<Entity.Approval.ApprovalStep>();

    public async Task AddAsync(Entity.Approval.ApprovalStep approvalStep)
    {
        await _dbSet.AddAsync(approvalStep);
    }

    public async Task<int> GetMaxIdAsync()
    {
        return await _dbSet.MaxAsync(e => (int?)e.Id) ?? 0;
    }
}
