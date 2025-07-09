using System;
using System.Threading.Tasks;
using MasjidOnline.Data.EntityFramework.DataContext;
using MasjidOnline.Data.Interface.Definition;
using Microsoft.EntityFrameworkCore;

namespace MasjidOnline.Data.EntityFramework.SqLite.Initializer;

public class SessionInitializer(
    SessionDataContext _sessionDataContext,
    ISessionsDefinition _sessionDefinition) : MasjidOnline.Data.Initializer.SessionInitializer(_sessionDefinition)
{
    protected override async Task CreateTableSessionSettingAsync()
    {
        FormattableString sql = @$"
            CREATE TABLE SessionSetting
            (
                Id INTEGER PRIMARY KEY,
                Description TEXT NOT NULL COLLATE NOCASE,
                Value TEXT NOT NULL COLLATE NOCASE
            )";

        await _sessionDataContext.Database.ExecuteSqlAsync(sql);
    }

    protected override async Task CreateTableSessionAsync()
    {
        FormattableString sql = @$"
            CREATE TABLE Session
            (
                Id INTEGER PRIMARY KEY,
                Digest BLOB NOT NULL,
                DateTime TEXT NOT NULL,
                PreviousId INTEGER,
                UserId INTEGER NOT NULL,
                ApplicationCulture INTEGER NOT NULL
            )";

        await _sessionDataContext.Database.ExecuteSqlAsync(sql);


        sql = $@"CREATE INDEX SessionDateTime ON Session (DateTime)";

        await _sessionDataContext.Database.ExecuteSqlAsync(sql);
    }
}
