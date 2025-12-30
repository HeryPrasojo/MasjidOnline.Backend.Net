using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MasjidOnline.Data.Interface.Repository.Person;
using MasjidOnline.Data.Interface.ViewModel.Person;
using Microsoft.EntityFrameworkCore;

namespace MasjidOnline.Data.EntityFramework.Repository.Person;

public class PersonRepository(DbContext _dbContext) : IPersonRepository
{
    private readonly DbSet<Entity.Person.Person> _dbSet = _dbContext.Set<Entity.Person.Person>();

    public async Task AddAsync(Entity.Person.Person person)
    {
        await _dbSet.AddAsync(person);
    }

    public async Task<IEnumerable<ForGetNames>> GetNamesAsync(IEnumerable<int> userIds)
    {
        return await _dbSet.Where(e => userIds.Any(i => i == e.UserId))
            .Select(e => new ForGetNames
            {
                Name = e.Name,
                UserId = e.UserId!.Value,
            })
            .ToArrayAsync();
    }

    public async Task<int> GetMaxIdAsync()
    {
        return await _dbSet.MaxAsync(e => (int?)e.Id) ?? 0;
    }
}
