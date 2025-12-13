using System;
using System.Linq;
using System.Threading.Tasks;
using MasjidOnline.Data.Interface.Repository.User;
using MasjidOnline.Data.Interface.ViewModel.Repository;
using MasjidOnline.Data.Interface.ViewModel.User.Internal;
using MasjidOnline.Entity.User;
using Microsoft.EntityFrameworkCore;

namespace MasjidOnline.Data.EntityFramework.Repository.User;

public class InternalUserRepository(DbContext _dbContext) : IInternalUserRepository
{
    private readonly DbSet<InternalUser> _dbSet = _dbContext.Set<InternalUser>();

    public async Task AddAsync(InternalUser internalUser)
    {
        await _dbSet.AddAsync(internalUser);
    }

    public async Task AddAndSaveAsync(InternalUser internalUser)
    {
        await _dbSet.AddAsync(internalUser);

        await _dbContext.SaveChangesAsync();
    }

    //public async Task<bool> AnyAsync(string emailAddress, InternalUserStatus status)
    //{
    //    return await _dbSet.AnyAsync(e => (e.EmailAddress == emailAddress) && (e.Status == status));
    //}

    //public async Task<ForApprove?> GetForApproveAsync(int id)
    //{
    //    return await _dbSet.Where(e => e.Id == id)
    //        .Select(e => new ForApprove
    //        {
    //            EmailAddress = e.EmailAddress,
    //            Status = e.Status,
    //        })
    //        .FirstOrDefaultAsync();
    //}

    public async Task<int> GetMaxIdAsync()
    {
        return await _dbSet.MaxAsync(e => (int?)e.Id) ?? 0;
    }

    public async Task<ManyResult<ManyRecord>> GetManyAsync(
        InternalUserStatus? status = default,
        ManyOrderBy getManyOrderBy = default,
        OrderByDirection orderByDirection = default,
        int skip = 0,
        int take = 1)
    {
        var queryable = _dbSet.AsQueryable();

        if (status != default)
            queryable = queryable.Where(e => e.Status == status);


        var countTask = queryable.LongCountAsync();


        if (getManyOrderBy == ManyOrderBy.DateTime)
        {
            if (orderByDirection == OrderByDirection.Descending) queryable = queryable.OrderByDescending(e => e.DateTime);
            else queryable = queryable.OrderBy(e => e.DateTime);
        }


        var count = await countTask;

        return new()
        {
            Records = await queryable.Skip(skip)
                .Take(take)
                .Select(e => new ManyRecord
                {
                    AddUserId = e.AddUserId,
                    DateTime = e.DateTime,
                    Description = e.Description,
                    Id = e.Id,
                    Status = e.Status,
                    UpdateDateTime = e.UpdateDateTime,
                    UpdateUserId = e.UpdateUserId,
                    UserId = e.UserId,
                })
                .ToArrayAsync(),
            RecordCount = count,
        };
    }

    public async Task<One?> GetOneAsync(int id)
    {
        return await _dbSet.Where(e => e.Id == id)
            .Select(e => new One
            {
                AddUserId = e.AddUserId,
                DateTime = e.DateTime,
                Description = e.Description,
                Status = e.Status,
                UpdateDateTime = e.UpdateDateTime,
                UpdateUserId = e.UpdateUserId,
                UserId = e.UserId,
            })
            .FirstOrDefaultAsync();
    }

    public async Task<InternalUserStatus> GetStatusAsync(int id)
    {
        return await _dbSet.Where(e => e.Id == id)
            .Select(e => e.Status)
            .FirstOrDefaultAsync();
    }

    public void SetStatus(int id, InternalUserStatus status, string? description, DateTime updateDateTime, int updateUserId)
    {
        var internalUser = new InternalUser
        {
            Description = description,
            Id = id,
            Status = status,
            UpdateDateTime = updateDateTime,
            UpdateUserId = updateUserId,
        };

        var entityEntry = _dbSet.Attach(internalUser);

        entityEntry.Property(e => e.Description).IsModified = true;
        entityEntry.Property(e => e.Status).IsModified = true;
        entityEntry.Property(e => e.UpdateDateTime).IsModified = true;
        entityEntry.Property(e => e.UpdateUserId).IsModified = true;
    }

    public async Task SetStatusAndSaveAsync(int id, InternalUserStatus status, string? description, DateTime updateDateTime, int updateUserId)
    {
        SetStatus(id, status, description, updateDateTime, updateUserId);

        await _dbContext.SaveChangesAsync();
    }
}
