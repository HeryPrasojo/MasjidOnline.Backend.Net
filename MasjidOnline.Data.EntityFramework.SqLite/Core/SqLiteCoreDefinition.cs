using System;
using System.Threading.Tasks;
using MasjidOnline.Data.Interface.Core;
using Microsoft.EntityFrameworkCore;

namespace MasjidOnline.Data.EntityFramework.SqLite.Core;

public class SqLiteCoreDefinition(CoreDataContext _dataContext) : Definition, ICoreDefinition
{
    public override async Task<bool> CheckTableExistsAsync(string name)
    {
        FormattableString sql = $"SELECT COUNT(*) Value FROM sqlite_master WHERE type='table' AND name={name}";

        var queryable = _dataContext.Database.SqlQuery<long>(sql);

        var count = await queryable.SingleAsync();

        var exists = count == 1L;

        return exists;
    }
}
