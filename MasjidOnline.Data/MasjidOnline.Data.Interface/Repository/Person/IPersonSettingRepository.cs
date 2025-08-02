using System.Threading.Tasks;
using MasjidOnline.Entity.Person;

namespace MasjidOnline.Data.Interface.Repository.Person;

public interface IPersonSettingRepository
{
    Task AddAndSaveAsync(PersonSetting personSetting);
}
