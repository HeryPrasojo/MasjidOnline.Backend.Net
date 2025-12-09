using System.Threading.Tasks;
using MasjidOnline.Data.Interface.Repository.Person;
using Microsoft.EntityFrameworkCore;

namespace MasjidOnline.Data.EntityFramework.Repository.Person;

public class PersonRepository(DbContext _dbContext) : IPersonRepository
{
    private readonly DbSet<Entity.Person.Person> _dbSet = _dbContext.Set<Entity.Person.Person>();

    public async Task AddAsync(Entity.Person.Person person)
    {
        await _dbSet.AddAsync(person);
    }

    public async Task<int> GetMaxIdAsync()
    {
        return await _dbSet.MaxAsync(e => (int?)e.Id) ?? 0;
    }
}
