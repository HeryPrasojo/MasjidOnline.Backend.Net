using System.Threading.Tasks;
using MasjidOnline.Business.Model.Infaq.Infaq;
using MasjidOnline.Business.Model.Responses;
using MasjidOnline.Data.Interface;

namespace MasjidOnline.Business.Infaq.Interface.Infaq;

public interface IGetViewBusiness
{
    Task<Response<ViewResponse>> GetAsync(Model.Session.Session session, IData _data, ViewRequest? getViewRequest);
}
