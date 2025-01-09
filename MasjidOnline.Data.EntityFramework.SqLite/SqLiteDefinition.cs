using System;
using System.Threading.Tasks;
using MasjidOnline.Data.Interface;
using Microsoft.EntityFrameworkCore;

namespace MasjidOnline.Data.EntityFramework.SqLite;

public class SqLiteDefinition(DbContext dbContext) : IDefinition
{
    public async Task<bool> CheckTableExistsAsync(string name)
    {
        FormattableString sql = $"SELECT COUNT(*) Value FROM sqlite_master WHERE type='table' AND name={name}";

        var queryable = dbContext.Database.SqlQuery<long>(sql);

        var count = await queryable.SingleAsync();

        var exists = count == 1L;

        return exists;
    }
}
