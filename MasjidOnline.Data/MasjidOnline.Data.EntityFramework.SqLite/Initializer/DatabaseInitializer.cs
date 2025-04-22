using System;
using System.Threading.Tasks;
using MasjidOnline.Data.EntityFramework.DataContext;
using MasjidOnline.Data.Interface.Definition;
using Microsoft.EntityFrameworkCore;

namespace MasjidOnline.Data.EntityFramework.SqLite.Initializer;

public class DatabaseInitializer(
    DatabaseDataContext _databaseDataContext,
    IDatabaseDefinition _databaseDefinition) : MasjidOnline.Data.Initializer.DatabaseInitializer(_databaseDefinition)
{
    protected override async Task<int> CreateTableDatabaseSettingAsync()
    {
        FormattableString sql = @$"
            CREATE TABLE DatabaseSetting
            (
                Id INTEGER PRIMARY KEY,
                Description TEXT NOT NULL COLLATE NOCASE,
                Value TEXT NOT NULL COLLATE NOCASE
            )";

        return await _databaseDataContext.Database.ExecuteSqlAsync(sql);
    }

    protected override async Task<int> CreateTableTableAsync()
    {
        FormattableString sql = @$"
            CREATE TABLE Table
            (
                Id INTEGER PRIMARY KEY,
            )";

        return await _databaseDataContext.Database.ExecuteSqlAsync(sql);
    }
}
