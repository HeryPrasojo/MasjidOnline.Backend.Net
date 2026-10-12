using System.Threading.Tasks;
using MasjidOnline.Data.Interface.ViewModel.Approval;
using MasjidOnline.Entity.Approval;

namespace MasjidOnline.Data.Interface.Repository.Approval;

public interface IApprovalRepository
{
    Task AddAsync(Entity.Approval.Approval approval);
    Task<int> GetIdAsync(ApprovalType approvalType, int typeId);
    Task<int> GetMaxIdAsync();
    Task<View?> GetViewAsync(ApprovalType approvalType, int typeId);
    Task SetStatusAsync(int id, int step, ApprovalStatus status);
}
