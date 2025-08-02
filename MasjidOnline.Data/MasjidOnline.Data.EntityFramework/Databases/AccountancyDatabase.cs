using MasjidOnline.Data.EntityFramework.Repository.Accountancy;
using MasjidOnline.Data.Interface.Databases;
using MasjidOnline.Data.Interface.Repository.Accountancy;
using Microsoft.EntityFrameworkCore;

namespace MasjidOnline.Data.EntityFramework.Databases;

public class AccountancyDatabase(
    DbContext _dbContext) : Database(_dbContext), IAccountancyDatabase
{
    private IAccountancySettingRepository? _accountancySettingRepository;
    private IExpenditureRepository? _expenditureRepository;

    public IAccountancySettingRepository AccountancySetting => _accountancySettingRepository ??= new AccountancySettingRepository(_dbContext);
    public IExpenditureRepository Expenditure => _expenditureRepository ??= new ExpenditureRepository(_dbContext);
}