using MasjidOnline.Business.Infaq.Interface.Model.Success;
using MasjidOnline.Business.Interface.Model.Responses;
using MasjidOnline.Business.Session.Interface;
using MasjidOnline.Data.Interface;

namespace MasjidOnline.Business.Infaq.Interface.Success;

public interface IAddBusiness
{
    Task<Response> AddAsync(IData _data, ISessionBusiness _sessionBusiness, AddRequest? addRequest);
}
