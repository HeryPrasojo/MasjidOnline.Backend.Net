using System;
using System.Threading.Tasks;
using MasjidOnline.Data.Interface.ViewModel.Repository;
using MasjidOnline.Data.Interface.ViewModel.User.Internal;
using MasjidOnline.Entity.User;

namespace MasjidOnline.Data.Interface.Repository.User;

public interface IInternalUserRepository
{
    Task AddAndSaveAsync(InternalUser internalUser);
    Task AddAsync(InternalUser internalUser);
    Task<bool> AnyNewAsync(int userId);

    //Task<bool> AnyAsync(string emailAddress, InternalUserStatus status);
    //Task<ForApprove?> GetForApproveAsync(int id);
    Task<ManyResult<ManyRecord>> GetTableAsync(InternalUserStatus? status = default, ManyOrderBy getTableOrderBy = default, OrderByDirection orderByDirection = default, int skip = 0, int take = 1);
    Task<int> GetMaxIdAsync();
    Task<View?> GetFirstOrDefaultAsync(int id);
    Task<InternalUserStatus> GetStatusAsync(int id);
    void SetStatus(int id, InternalUserStatus status, string? description, DateTime updateDateTime, int updateUserId);
    Task SetStatusAndSaveAsync(int id, InternalUserStatus status, string? description, DateTime updateDateTime, int updateUserId);
}
