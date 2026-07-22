using MasjidOnline.Data.Interface.Repository.Approval;

namespace MasjidOnline.Data.Interface.Databases;

public interface IApprovalDatabase : IDatabase
{
    IApprovalSettingRepository ApprovalSetting { get; }
    IApprovalRepository Approval { get; }
    IApprovalStepRepository ApprovalStep { get; }
}
