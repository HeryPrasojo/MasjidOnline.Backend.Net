using System;
using System.Threading.Tasks;
using MasjidOnline.Data.Interface.ViewModel.Verification.VerificationCode;
using MasjidOnline.Entity.User;
using MasjidOnline.Entity.Verification;

namespace MasjidOnline.Data.Interface.Repository.Verification;

public interface IVerificationCodeRepository
{
    Task AddAndSaveAsync(VerificationCode verificationCode);
    Task AddAsync(VerificationCode verificationCode);
    Task<OneByCode?> GetByCodeAsync(byte[] code);
    Task<int> GetLastIdByContactAsync(ContactType contactType, string contact);
    Task<int> GetLastIdByUserIdAsync(int userId);
    Task<int> GetMaxIdAsync();
    void SetUseDateTime(int id, DateTime useDateTime);
}
