using System.Threading.Tasks;
using MasjidOnline.Entity.Accountancy;

namespace MasjidOnline.Data.Interface.Repository.Accountancy;

public interface IAccountancySettingRepository
{
    Task AddAndSaveAsync(AccountancySetting accountancySetting);
}
