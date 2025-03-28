using MasjidOnline.Business.Infaq.Interface.Model.Expire;
using MasjidOnline.Business.Model.Responses;
using MasjidOnline.Business.Session.Interface;
using MasjidOnline.Data.Interface;

namespace MasjidOnline.Business.Infaq.Interface.Expire;

public interface IAddBusiness
{
    Task<Response> AddAsync(IData _data, ISessionBusiness _sessionBusiness, AddRequest? addRequest);
}
