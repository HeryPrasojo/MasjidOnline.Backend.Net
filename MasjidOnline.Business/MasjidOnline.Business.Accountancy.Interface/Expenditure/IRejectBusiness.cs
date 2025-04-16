using System.Threading.Tasks;
using MasjidOnline.Business.Accountancy.Interface.Model.Expenditure;
using MasjidOnline.Business.Model.Responses;
using MasjidOnline.Data.Interface;

namespace MasjidOnline.Business.Accountancy.Interface.Expenditure;

public interface IRejectBusiness
{
    Task<Response> RejectAsync(Session.Interface.Model.Session session, IData _data, RejectRequest? rejectRequest);
}
