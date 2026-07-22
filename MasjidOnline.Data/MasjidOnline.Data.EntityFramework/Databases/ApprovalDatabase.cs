using MasjidOnline.Data.EntityFramework.Repository.Approval;
using MasjidOnline.Data.Interface.Databases;
using MasjidOnline.Data.Interface.Repository.Approval;
using Microsoft.EntityFrameworkCore;

namespace MasjidOnline.Data.EntityFramework.Databases;

public class ApprovalDatabase(
    DbContext _dbContext) : Database(_dbContext), IApprovalDatabase
{
    private IApprovalRepository? _approvalRepository;
    private IApprovalSettingRepository? _approvalSettingRepository;
    private IApprovalStepRepository? _approvalStepRepository;

    public IApprovalRepository Approval => _approvalRepository ??= new ApprovalRepository(_dbContext);
    public IApprovalSettingRepository ApprovalSetting => _approvalSettingRepository ??= new ApprovalSettingRepository(_dbContext);
    public IApprovalStepRepository ApprovalStep => _approvalStepRepository ??= new ApprovalStepRepository(_dbContext);
}