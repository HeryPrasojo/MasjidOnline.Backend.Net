using MasjidOnline.Business.Infaq.Interface.Model.Infaq;
using MasjidOnline.Data.Interface;

namespace MasjidOnline.Business.Infaq.Interface.Infaq;

public interface IGetOneBusiness
{
    Task<GetOneResponse> GetAsync(Session.Interface.Model.Session, IData _data, GetOneRequest? getOneRequest);
}
