﻿using MasjidOnline.Entity.Users;
using Microsoft.EntityFrameworkCore;

namespace MasjidOnline.Data.EntityFramework.DataContext;

public class UsersDataContext(DbContextOptions _dbContextOptions) : DbContext(_dbContextOptions)
{
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<PasswordCode>();
        modelBuilder.Entity<Permission>();
        modelBuilder.Entity<User>();
        modelBuilder.Entity<UserEmailAddress>();

        modelBuilder.Entity<UserSetting>();
    }
}
