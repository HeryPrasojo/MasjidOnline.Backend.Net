using System.Threading.Tasks;
using MasjidOnline.Business.Accountancy.Interface.Model.Expenditure;
using MasjidOnline.Business.Model.Responses;
using MasjidOnline.Data.Interface;

namespace MasjidOnline.Business.Accountancy.Interface.Expenditure;

public interface ICancelBusiness
{
    Task<Response> CancelAsync(Session.Interface.Model.Session session, IData _data, CancelRequest? cancelRequest);
}
