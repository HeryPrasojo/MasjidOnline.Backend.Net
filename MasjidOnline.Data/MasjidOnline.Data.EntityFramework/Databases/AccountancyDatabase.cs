using MasjidOnline.Data.EntityFramework.DataContext;
using MasjidOnline.Data.EntityFramework.Repository.Accountancy;
using MasjidOnline.Data.Interface.Databases;
using MasjidOnline.Data.Interface.Repository.Accountancy;

namespace MasjidOnline.Data.EntityFramework.Databases;

public class AccountancyDatabase(
    AccountancyDataContext _accountancyDataContext) : Database(_accountancyDataContext), IAccountancyDatabase
{
    private IAccountancySettingRepository? _accountancySettingRepository;
    private IExpenditureRepository? _userInternalPermissionLogRepository;

    public IAccountancySettingRepository AccountancySetting => _accountancySettingRepository ??= new AccountancySettingRepository(_accountancyDataContext);
    public IExpenditureRepository Expenditure => _userInternalPermissionLogRepository ??= new ExpenditureRepository(_accountancyDataContext);
}