using System.Threading.Tasks;
using MasjidOnline.Entity.Approval;

namespace MasjidOnline.Data.Interface.Repository.Approval;

public interface IApprovalSettingRepository
{
    Task AddAndSaveAsync(ApprovalSetting approvalSetting);
}
