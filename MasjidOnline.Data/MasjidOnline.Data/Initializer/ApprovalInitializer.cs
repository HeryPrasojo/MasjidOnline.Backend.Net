using System.Threading.Tasks;
using MasjidOnline.Data.Interface;
using MasjidOnline.Data.Interface.Definition;
using MasjidOnline.Entity.Approval;

namespace MasjidOnline.Data.Initializer;

public abstract class ApprovalInitializer(IApprovalDefinition _approvalDefinition)
{
    public async Task InitializeDatabaseAsync(IData data)
    {
        var settingTableExists = await _approvalDefinition.CheckTableExistsAsync(nameof(ApprovalSetting));

        if (!settingTableExists)
        {
            await CreateTableApprovalSettingAsync();

            await CreateTableApprovalAsync();
            await CreateTableApprovalStepAsync();


            var approvalSetting = new ApprovalSetting
            {
                Id = ApprovalSettingId.DatabaseVersion,
                Description = nameof(ApprovalSettingId.DatabaseVersion),
                Value = "1",
            };

            await data.Approval.ApprovalSetting.AddAndSaveAsync(approvalSetting);
        }
    }


    protected abstract Task CreateTableApprovalAsync();
    protected abstract Task CreateTableApprovalSettingAsync();
    protected abstract Task CreateTableApprovalStepAsync();
}
