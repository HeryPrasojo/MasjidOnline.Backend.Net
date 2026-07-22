using System.Threading.Tasks;

namespace MasjidOnline.Data.Interface.Repository.Approval;

public interface IApprovalRepository
{
    Task AddAsync(Entity.Approval.Approval approval);
    Task<int> GetMaxIdAsync();
}
