using System.Threading.Tasks;
using MasjidOnline.Data.Interface.Repository.Person;
using MasjidOnline.Entity.Person;
using Microsoft.EntityFrameworkCore;

namespace MasjidOnline.Data.EntityFramework.Repository.Person;

public class PersonSettingRepository(DbContext _dbContext) : IPersonSettingRepository
{
    private readonly DbSet<PersonSetting> _dbSet = _dbContext.Set<PersonSetting>();

    public async Task AddAndSaveAsync(PersonSetting personSetting)
    {
        await _dbSet.AddAsync(personSetting);

        await _dbContext.SaveChangesAsync();
    }
}
