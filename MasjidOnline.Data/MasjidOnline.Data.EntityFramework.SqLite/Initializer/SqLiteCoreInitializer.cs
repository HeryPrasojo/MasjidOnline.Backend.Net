﻿using System;
using System.Threading.Tasks;
using MasjidOnline.Data.EntityFramework.DataContext;
using MasjidOnline.Data.Initializer;
using MasjidOnline.Data.Interface.Definition;
using Microsoft.EntityFrameworkCore;

namespace MasjidOnline.Data.EntityFramework.SqLite.Initializer;

public class SqLiteCoreInitializer(
    CoreDataContext _coreDataContext,
    ICoreDefinition _coreDefinition) : CoreInitializer(_coreDefinition)
{
    protected override async Task<int> CreateTableCoreSettingAsync()
    {
        FormattableString sql = @$"
            CREATE TABLE CoreSetting
            (
                Id INTEGER PRIMARY KEY,
                Description TEXT NOT NULL COLLATE NOCASE,
                Value TEXT NOT NULL COLLATE NOCASE
            )";

        return await _coreDataContext.Database.ExecuteSqlAsync(sql);
    }
}
