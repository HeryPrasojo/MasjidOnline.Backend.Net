using System.Threading.Tasks;
using MasjidOnline.Business.Model.Infaq.Success;
using MasjidOnline.Business.Model.Responses;
using MasjidOnline.Data.Interface;

namespace MasjidOnline.Business.Infaq.Interface.Success;

public interface IAddBusiness
{
    Task<Response> AddAsync(IData _data, Model.Session.Session session, AddRequest? addRequest);
}
