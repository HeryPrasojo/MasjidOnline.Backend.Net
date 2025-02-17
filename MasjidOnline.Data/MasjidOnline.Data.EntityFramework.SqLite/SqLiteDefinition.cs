using System;
using System.Threading.Tasks;
using MasjidOnline.Data.Interface;
using MasjidOnline.Data.Interface.Definition;
using Microsoft.EntityFrameworkCore;

namespace MasjidOnline.Data.EntityFramework.SqLite;

public class SqLiteDefinition<TDataContext>(TDataContext tDataContext) :
    IDefinition,
    IAuditDefinition,
    ICaptchaDefinition,
    ICoreDefinition,
    IEventDefinition,
    ISessionsDefinition,
    IInfaqsDefinition,
    IUsersDefinition
    where TDataContext : DbContext
{
    public async Task<bool> CheckTableExistsAsync(string name)
    {
        FormattableString sql = $"SELECT COUNT(*) Value FROM sqlite_master WHERE type='table' AND name={name}";

        var queryable = tDataContext.Database.SqlQuery<long>(sql);

        var count = await queryable.SingleAsync();

        var exists = count == 1L;

        return exists;
    }
}
