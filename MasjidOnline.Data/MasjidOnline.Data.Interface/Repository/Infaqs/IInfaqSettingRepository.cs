using System.Threading.Tasks;
using MasjidOnline.Entity.Infaqs;

namespace MasjidOnline.Data.Interface.Repository.Infaqs;

public interface IInfaqSettingRepository
{
    Task AddAsync(InfaqSetting setting);
}
