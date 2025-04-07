using MasjidOnline.Business.Infaq.Interface.Model.Success;
using MasjidOnline.Business.Model.Responses;
using MasjidOnline.Data.Interface;

namespace MasjidOnline.Business.Infaq.Interface.Success;

public interface IAddBusiness
{
    Task<Response> AddAsync(IData _data, Session.Interface.Session _sessionBusiness, AddRequest? addRequest);
}
