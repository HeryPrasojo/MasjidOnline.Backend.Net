using System.Threading.Tasks;
using MasjidOnline.Entity.Verification;

namespace MasjidOnline.Data.Interface.Repository.Verification;

public interface IVerificationSettingRepository
{
    Task AddAndSaveAsync(VerificationSetting databaseSetting);
}
