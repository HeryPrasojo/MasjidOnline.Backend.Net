using System.Threading.Tasks;
using MasjidOnline.Data.EntityFramework.DataContext;
using MasjidOnline.Data.Interface.Repository.Person;
using MasjidOnline.Entity.Person;
using Microsoft.EntityFrameworkCore;

namespace MasjidOnline.Data.EntityFramework.Repository.Person;

// todo low change *DataContext to DbContext
public class PersonSettingRepository(PersonDataContext _personDataContext) : IPersonSettingRepository
{
    private readonly DbSet<PersonSetting> _dbSet = _personDataContext.Set<PersonSetting>();

    public async Task AddAsync(PersonSetting personSetting)
    {
        await _dbSet.AddAsync(personSetting);
    }
}
