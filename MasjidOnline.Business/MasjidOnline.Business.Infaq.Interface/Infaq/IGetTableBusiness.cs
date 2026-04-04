using System.Threading.Tasks;
using MasjidOnline.Business.Model.Infaq.Infaq;
using MasjidOnline.Business.Model.Responses;
using MasjidOnline.Data.Interface;

namespace MasjidOnline.Business.Infaq.Interface.Infaq;

public interface IGetTableBusiness
{
    Task<Response<TableResponse<TableResponseRecord>>> GetAsync(Model.Session.Session session, IData _data, TableRequest? getTableRequest);
}
