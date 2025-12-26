using System.Threading.Tasks;
using MasjidOnline.Business.Model.Infaq.Infaq;
using MasjidOnline.Business.Model.Responses;
using MasjidOnline.Data.Interface;

namespace MasjidOnline.Business.Infaq.Interface.Infaq;

public interface IAddByAnonymBusiness
{
    Task<Response> AddAsync(IData _data, Model.Session.Session session, AddByAnonymRequest? addByAnonymRequest);
}
