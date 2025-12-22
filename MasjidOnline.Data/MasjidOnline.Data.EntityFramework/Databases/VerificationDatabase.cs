using MasjidOnline.Data.EntityFramework.Repository.Verification;
using MasjidOnline.Data.Interface.Databases;
using MasjidOnline.Data.Interface.Repository.Verification;
using Microsoft.EntityFrameworkCore;

namespace MasjidOnline.Data.EntityFramework.Databases;

public class VerificationDatabase(
    DbContext _dbContext) : Database(_dbContext), IVerificationDatabase
{
    private IVerificationCodeRepository? _verificationCodeRepository;
    private IVerificationSettingRepository? _verificationSettingRepository;

    public IVerificationCodeRepository VerificationCode => _verificationCodeRepository ??= new VerificationCodeRepository(_dbContext);

    public IVerificationSettingRepository VerificationSetting => _verificationSettingRepository ??= new VerificationSettingRepository(_dbContext);
}