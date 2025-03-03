using System;
using System.Threading.Tasks;
using MasjidOnline.Data.Interface.Model.User;
using MasjidOnline.Entity.User;

namespace MasjidOnline.Data.Interface.Repository.User;

public interface IPasswordCodeRepository
{
    Task AddAsync(PasswordCode passwordCode);
    Task<PasswordCodeForUserSetPassword?> GetForUserSetPasswordAsync(byte[] code);
    void UpdateUseDateTime(byte[] code, DateTime useDateTime);
}
