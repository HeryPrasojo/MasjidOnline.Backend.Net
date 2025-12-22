using MasjidOnline.Data.Interface.Repository.Verification;

namespace MasjidOnline.Data.Interface.Databases;

public interface IVerificationDatabase : IDatabase
{
    IVerificationCodeRepository VerificationCode { get; }
    IVerificationSettingRepository VerificationSetting { get; }
}
