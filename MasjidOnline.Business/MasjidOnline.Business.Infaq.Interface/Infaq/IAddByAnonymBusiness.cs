using System.Threading.Tasks;
using MasjidOnline.Business.Infaq.Interface.Model.Infaq;
using MasjidOnline.Business.Model.Responses;
using MasjidOnline.Data.Interface;

namespace MasjidOnline.Business.Infaq.Interface.Infaq;

public interface IAddByAnonymBusiness
{
    Task<Response> AddAsync(IData _data, Session.Interface.Model.Session session, AddByAnonymRequest? addByAnonymRequest);
}
