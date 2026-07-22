using System.Threading.Tasks;
using MasjidOnline.Entity.Approval;

namespace MasjidOnline.Data.Interface.Repository.Approval;

public interface IApprovalStepRepository
{
    Task AddAsync(ApprovalStep approvalStep);
    Task<int> GetMaxIdAsync();
}
