using System.Threading.Tasks;
using MasjidOnline.Business.Model.Infaq.Expire;
using MasjidOnline.Business.Model.Responses;
using MasjidOnline.Data.Interface;

namespace MasjidOnline.Business.Infaq.Interface.Expire;

public interface IAddBusiness
{
    Task<Response> AddAsync(IData _data, Model.Session.Session session, AddRequest? addRequest);
}
