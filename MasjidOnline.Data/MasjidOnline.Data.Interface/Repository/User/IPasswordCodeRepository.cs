using System;
using System.Threading.Tasks;
using MasjidOnline.Data.Interface.ViewModel.User.PasswordCode;
using MasjidOnline.Entity.User;

namespace MasjidOnline.Data.Interface.Repository.User;

public interface IPasswordCodeRepository
{
    Task AddAsync(PasswordCode passwordCode);
    Task<ForSetPassword?> GetForSetPasswordAsync(int userId);
    Task<int?> GetUserIdForSetPasswordAsync(byte[] code);
    void SetUseDateTime(byte[] code, DateTime useDateTime);
}
