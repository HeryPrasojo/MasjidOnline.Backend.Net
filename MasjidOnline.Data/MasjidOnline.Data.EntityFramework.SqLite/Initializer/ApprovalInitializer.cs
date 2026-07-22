using System;
using System.Threading.Tasks;
using MasjidOnline.Data.EntityFramework.DataContext;
using MasjidOnline.Data.Interface.Definition;
using Microsoft.EntityFrameworkCore;

namespace MasjidOnline.Data.EntityFramework.SqLite.Initializer;

public class ApprovalInitializer(
    ApprovalDataContext _approvalDataContext,
    IApprovalDefinition _approvalDefinition) : MasjidOnline.Data.Initializer.ApprovalInitializer(_approvalDefinition)
{
    protected override async Task CreateTableApprovalSettingAsync()
    {
        FormattableString sql = @$"
            CREATE TABLE ApprovalSetting
            (
                Id INTEGER PRIMARY KEY,
                Description TEXT NOT NULL COLLATE NOCASE,
                Value TEXT NOT NULL COLLATE NOCASE
            )";

        await _approvalDataContext.Database.ExecuteSqlAsync(sql);
    }

    protected override async Task CreateTableApprovalAsync()
    {
        FormattableString sql = @$"
            CREATE TABLE Approval
            (
                Id INTEGER PRIMARY KEY,
                Type INTEGER NOT NULL,
                TypeId INTEGER NOT NULL,
                DateTime DATETIME NOT NULL,
                UserId INTEGER NOT NULL,
                Description TEXT,
                Step INTEGER NOT NULL,
                Status INTEGER NOT NULL
            )";

        await _approvalDataContext.Database.ExecuteSqlAsync(sql);
    }

    protected override async Task CreateTableApprovalStepAsync()
    {
        FormattableString sql = @$"
            CREATE TABLE ApprovalStep
            (
                Id INTEGER PRIMARY KEY,
                ApprovalId INTEGER NOT NULL,
                Step INTEGER NOT NULL,
                DateTime DATETIME NOT NULL,
                UserId INTEGER NOT NULL,
                Status INTEGER NOT NULL,
                Description TEXT
            )";

        await _approvalDataContext.Database.ExecuteSqlAsync(sql);
    }
}
