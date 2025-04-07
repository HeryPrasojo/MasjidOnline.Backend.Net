using MasjidOnline.Business.Infaq.Interface.Model.Void;
using MasjidOnline.Business.Model.Responses;
using MasjidOnline.Data.Interface;

namespace MasjidOnline.Business.Infaq.Interface.Void;

public interface IAddBusiness
{
    Task<Response> AddAsync(IData _data, Session.Interface.Session _sessionBusiness, AddRequest? addRequest);
}
