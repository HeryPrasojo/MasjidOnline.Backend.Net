using System;
using System.Threading.Tasks;
using MasjidOnline.Data.EntityFramework.DataContext;
using MasjidOnline.Data.Initializer;
using MasjidOnline.Data.Interface.Definition;
using Microsoft.EntityFrameworkCore;

namespace MasjidOnline.Data.EntityFramework.SqLite.Initializer;

public class SqLiteSessionsInitializer(
    SessionsDataContext _sessionDataContext,
    ISessionsDefinition _sessionDefinition) : SessionInitializer(_sessionDefinition)
{
    protected override async Task<int> CreateTableSessionSettingAsync()
    {
        FormattableString sql = @$"
            CREATE TABLE SessionSetting
            (
                Id INTEGER PRIMARY KEY,
                Description TEXT NOT NULL,
                Value TEXT NOT NULL
            )";

        return await _sessionDataContext.Database.ExecuteSqlAsync(sql);
    }

    protected override async Task<int> CreateTableSessionAsync()
    {
        FormattableString sql = @$"
            CREATE TABLE Session
            (
                Id INTEGER PRIMARY KEY,
                Digest INTEGER NOT NULL,
                DateTime TEXT NOT NULL,
                PreviousId BLOB,
                UserId INTEGER NOT NULL
            )";

        return await _sessionDataContext.Database.ExecuteSqlAsync(sql);
    }
}
