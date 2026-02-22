using MasjidOnline.Data.EntityFramework.Repository.Infaq;
using MasjidOnline.Data.Interface.Databases;
using MasjidOnline.Data.Interface.Repository.Infaq;
using Microsoft.EntityFrameworkCore;

namespace MasjidOnline.Data.EntityFramework.Databases;

public class InfaqDatabase(DbContext _dbContext) : Database(_dbContext), IInfaqDatabase
{
    private IInfaqRepository? _infaqRepository;
    private IInfaqSettingRepository? _infaqSettingRepository;

    public IInfaqRepository Infaq => _infaqRepository ??= new InfaqRepository(_dbContext);

    public IInfaqSettingRepository InfaqSetting => _infaqSettingRepository ??= new InfaqSettingRepository(_dbContext);
}
