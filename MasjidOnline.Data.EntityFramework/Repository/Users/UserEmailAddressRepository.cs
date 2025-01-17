﻿using System.Threading.Tasks;
using MasjidOnline.Data.EntityFramework.DataContext;
using MasjidOnline.Data.Interface.Repository.Users;
using MasjidOnline.Entity.Users;
using Microsoft.EntityFrameworkCore;

namespace MasjidOnline.Data.EntityFramework.Repository.Users;

public class UserEmailAddressRepository(UserDataContext _userDataContext) : IUserEmailAddressRepository
{
    private readonly DbSet<UserEmailAddress> _dbSet = _userDataContext.Set<UserEmailAddress>();

    public async Task AddAsync(UserEmailAddress userEmailAddress)
    {
        await _dbSet.AddAsync(userEmailAddress);
    }

    public async Task<int> GetMaxIdAsync()
    {
        return await _dbSet.MaxAsync(e => (int?)e.Id) ?? 0;
    }
}
