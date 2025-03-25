using MasjidOnline.Business.Infaq.Interface.Model.Infaq;
using MasjidOnline.Business.Interface.Model.Responses;
using MasjidOnline.Business.Session.Interface;
using MasjidOnline.Data.Interface;

namespace MasjidOnline.Business.Infaq.Interface.Infaq;

public interface IAddAnonymBusiness
{
    Task<Response> AddAsync(IData _data, ISessionBusiness _sessionBusiness, AddByAnonymRequest? addByAnonymRequest);
}
