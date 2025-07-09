using System;
using System.Threading.Tasks;
using MasjidOnline.Data.EntityFramework.DataContext;
using MasjidOnline.Data.Interface.Definition;
using Microsoft.EntityFrameworkCore;

namespace MasjidOnline.Data.EntityFramework.SqLite.Initializer;

public class DatabaseTemplateInitializer(
    DatabaseTemplateDataContext _databaseTemplateDataContext,
    IDatabaseTemplateDefinition _databaseTemplateDefinition) : MasjidOnline.Data.Initializer.DatabaseTemplateInitializer(_databaseTemplateDefinition)
{
    // todo template rename
    protected override async Task CreateTableDatabaseTemplateSettingAsync()
    {
        FormattableString sql = @$"
            CREATE TABLE DatabaseTemplateSetting
            (
                Id INTEGER PRIMARY KEY,
                Description TEXT NOT NULL COLLATE NOCASE,
                Value TEXT NOT NULL COLLATE NOCASE
            )";

        await _databaseTemplateDataContext.Database.ExecuteSqlAsync(sql);
    }

    protected override async Task CreateTableTableTemplateAsync()
    {
        FormattableString sql = @$"
            CREATE TABLE TableTemplate
            (
                Id INTEGER PRIMARY KEY,
            )";

        await _databaseTemplateDataContext.Database.ExecuteSqlAsync(sql);


        sql = $@"CREATE INDEX TableTemplateDateTime ON TableTemplate (DateTime)";

        await _databaseTemplateDataContext.Database.ExecuteSqlAsync(sql);
    }
}
