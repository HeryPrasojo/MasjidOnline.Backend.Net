using MasjidOnline.Data.EntityFramework.DataContext;
using MasjidOnline.Data.EntityFramework.Repository.Accountancy;
using MasjidOnline.Data.Interface.Databases;
using MasjidOnline.Data.Interface.Repository.Accountancy;

namespace MasjidOnline.Data.EntityFramework.Databases;

// todo low change *DataContext to DbContext
public class AccountancyDatabase(
    AccountancyDataContext _accountancyDataContext) : Database(_accountancyDataContext), IAccountancyDatabase
{
    private IAccountancySettingRepository? _accountancySettingRepository;
    private IExpenditureRepository? _expenditureRepository;

    public IAccountancySettingRepository AccountancySetting => _accountancySettingRepository ??= new AccountancySettingRepository(_accountancyDataContext);
    public IExpenditureRepository Expenditure => _expenditureRepository ??= new ExpenditureRepository(_accountancyDataContext);
}