using System.Threading.Tasks;
using MasjidOnline.Business.Accountancy.Interface.Model.Expenditure;
using MasjidOnline.Business.Model.Responses;
using MasjidOnline.Data.Interface;

namespace MasjidOnline.Business.Accountancy.Interface.Expenditure;

public interface IAddBusiness
{
    Task<Response> AddAsync(Session.Interface.Model.Session session, IData _data, AddRequest? addRequest);
}
