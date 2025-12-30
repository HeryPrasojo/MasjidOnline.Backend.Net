using System.Collections.Generic;
using System.Threading.Tasks;
using MasjidOnline.Data.Interface.ViewModel.Person;

namespace MasjidOnline.Data.Interface.Repository.Person;

public interface IPersonRepository
{
    Task AddAsync(Entity.Person.Person person);
    Task<int> GetMaxIdAsync();
    Task<IEnumerable<ForGetNames>> GetNamesAsync(IEnumerable<int> userIds);
}
