using MasjidOnline.Business.Infaq.Interface.Model.Expire;
using MasjidOnline.Business.Model.Responses;
using MasjidOnline.Data.Interface;

namespace MasjidOnline.Business.Infaq.Interface.Expire;

public interface IAddBusiness
{
    Task<Response> AddAsync(IData _data, Session.Interface.Session _sessionBusiness, AddRequest? addRequest);
}
