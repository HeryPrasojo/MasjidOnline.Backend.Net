using System.Threading.Tasks;
using MasjidOnline.Business.Model.Accountancy.Expenditure;
using MasjidOnline.Business.Model.Responses;
using MasjidOnline.Data.Interface;

namespace MasjidOnline.Business.Accountancy.Interface.Expenditure;

public interface IGetViewBusiness
{
    Task<Response<GetViewResponse>> GetAsync(IData _data, GetViewRequest? getViewRequest);
}
