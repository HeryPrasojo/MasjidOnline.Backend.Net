using MasjidOnline.Data.EntityFramework.Repository.DatabaseTemplate;
using MasjidOnline.Data.Interface.Databases;
using MasjidOnline.Data.Interface.Repository.DatabaseTemplate;
using Microsoft.EntityFrameworkCore;

namespace MasjidOnline.Data.EntityFramework.Databases;

public class DatabaseTemplateDatabase(
    DbContext _dbContext) : Database(_dbContext), IDatabaseTemplateDatabase
{
    private IDatabaseTemplateSettingRepository? _databaseTemplateSettingRepository;
    private ITableTemplateRepository? _tableTemplateRepository;

    public IDatabaseTemplateSettingRepository DatabaseTemplateSetting => _databaseTemplateSettingRepository ??= new DatabaseTemplateSettingRepository(_dbContext);
    public ITableTemplateRepository TableTemplate => _tableTemplateRepository ??= new TableTemplateRepository(_dbContext);
}