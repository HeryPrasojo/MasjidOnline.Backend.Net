using System.Linq;
using System.Threading.Tasks;
using MasjidOnline.Data.Interface.Repository.Approval;
using MasjidOnline.Data.Interface.ViewModel.Approval;
using MasjidOnline.Entity.Approval;
using Microsoft.EntityFrameworkCore;

namespace MasjidOnline.Data.EntityFramework.Repository.Approval;

public class ApprovalRepository(DbContext _dbContext) : IApprovalRepository
{
    private readonly DbSet<Entity.Approval.Approval> _dbSet = _dbContext.Set<Entity.Approval.Approval>();

    public async Task AddAsync(Entity.Approval.Approval approval)
    {
        await _dbSet.AddAsync(approval);
    }

    public async Task<int> GetIdAsync(ApprovalType approvalType, int typeId)
    {
        return await _dbSet.Where(e => (e.Type == approvalType) && (e.TypeId == typeId))
            .Select(e => e.Id)
            .FirstOrDefaultAsync();
    }

    public async Task<int> GetMaxIdAsync()
    {
        return await _dbSet.MaxAsync(e => (int?)e.Id) ?? 0;
    }

    public async Task<View?> GetViewAsync(ApprovalType approvalType, int typeId)
    {
        return await _dbSet.Where(e => (e.Type == approvalType) && (e.TypeId == typeId))
            .Select(e => new View
            {
                DateTime = e.DateTime,
                UserId = e.UserId,
                Description = e.Description
            })
            .FirstOrDefaultAsync();
    }

    public async Task SetStatusAsync(int id, int step, ApprovalStatus status)
    {
        var approval = new Entity.Approval.Approval
        {
            Id = id,
            Status = status,
            Step = step,
        };

        var entityEntry = _dbSet.Attach(approval);

        entityEntry.Property(e => e.Step).IsModified = true;
        entityEntry.Property(e => e.Status).IsModified = true;
    }
}
