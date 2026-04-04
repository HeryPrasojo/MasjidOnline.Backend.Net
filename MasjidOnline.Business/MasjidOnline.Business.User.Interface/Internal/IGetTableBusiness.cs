using System.Threading.Tasks;
using MasjidOnline.Business.Model.Responses;
using MasjidOnline.Business.Model.User.Internal;
using MasjidOnline.Data.Interface;

namespace MasjidOnline.Business.User.Interface.Internal;

public interface IGetTableBusiness
{
    Task<Response<GetTableResponse<GetTableResponseRecord>>> GetAsync(Business.Model.Session.Session session, IData _data, GetTableRequest? getTableRequest);
}
