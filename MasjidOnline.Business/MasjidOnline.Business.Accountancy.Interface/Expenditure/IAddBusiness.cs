using System.Threading.Tasks;
using MasjidOnline.Business.Model.Accountancy.Expenditure;
using MasjidOnline.Business.Model.Responses;
using MasjidOnline.Data.Interface;

namespace MasjidOnline.Business.Accountancy.Interface.Expenditure;

public interface IAddBusiness
{
    Task<Response> AddAsync(Model.Session.Session session, IData _data, AddRequest? addRequest);
}
