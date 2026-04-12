using System.Threading.Tasks;
using MasjidOnline.Business.Model.Authorization.UserInternalPermission;
using MasjidOnline.Business.Model.Responses;
using MasjidOnline.Business.Model.Session;
using MasjidOnline.Data.Interface;

namespace MasjidOnline.Business.Authorization.Interface.Authorization.UserInternalPermission;

public interface IUpdateBusiness
{
    Task<Response> UpdateAsync(IData _data, Session session, UpdateRequest? updateRequest);
}
