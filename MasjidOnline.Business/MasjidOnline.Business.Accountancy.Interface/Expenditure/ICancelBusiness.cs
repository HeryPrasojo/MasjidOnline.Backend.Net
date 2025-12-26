using System.Threading.Tasks;
using MasjidOnline.Business.Model.Accountancy.Expenditure;
using MasjidOnline.Business.Model.Responses;
using MasjidOnline.Data.Interface;

namespace MasjidOnline.Business.Accountancy.Interface.Expenditure;

public interface ICancelBusiness
{
    Task<Response> CancelAsync(Model.Session.Session session, IData _data, CancelRequest? cancelRequest);
}
