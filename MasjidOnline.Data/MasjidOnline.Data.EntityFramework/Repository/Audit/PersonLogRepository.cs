using System;
using System.Threading.Tasks;
using MasjidOnline.Data.Interface.Repository.Audit;
using MasjidOnline.Entity.Audit;
using Microsoft.EntityFrameworkCore;

namespace MasjidOnline.Data.EntityFramework.Repository.Audit;

public class PersonLogRepository(DbContext _dbContext) : IPersonLogRepository
{
    private readonly DbSet<PersonLog> _dbSet = _dbContext.Set<PersonLog>();

    public async Task AddAddAsync(int id, DateTime dateTime, int logUserId, Entity.Person.Person person)
    {
        var personLog = new PersonLog
        {
            Id = id,
            LogDateTime = dateTime,
            LogType = PersonLogType.Add,
            LogUserId = logUserId,

            PersonId = person.Id,
            Name = person.Name,
            UserId = person.UserId,
        };

        await _dbSet.AddAsync(personLog);
    }

    public async Task<int> GetMaxIdAsync()
    {
        return await _dbSet.MaxAsync(e => (int?)e.Id) ?? 0;
    }
}
