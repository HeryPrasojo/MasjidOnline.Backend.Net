using System.Threading.Tasks;

namespace MasjidOnline.Data.Interface.Repository.Person;

public interface IPersonRepository
{
    Task AddAsync(Entity.Person.Person person);
    Task<int> GetMaxIdAsync();
}
