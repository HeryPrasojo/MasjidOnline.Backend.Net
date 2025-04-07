using MasjidOnline.Business.Infaq.Interface.Model.Infaq;
using MasjidOnline.Business.Model.Responses;
using MasjidOnline.Data.Interface;

namespace MasjidOnline.Business.Infaq.Interface.Infaq;

public interface IAddAnonymBusiness
{
    Task<Response> AddAsync(IData _data, Session.Interface.Model.Session session, AddByAnonymRequest? addByAnonymRequest);
}
