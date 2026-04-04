using System.Threading.Tasks;
using MasjidOnline.Business.Model.Accountancy.Expenditure;
using MasjidOnline.Business.Model.Responses;
using MasjidOnline.Data.Interface;

namespace MasjidOnline.Business.Accountancy.Interface.Expenditure;

public interface IGetTableBusiness
{
    Task<Response<TableResponse<TableResponseRecord>>> GetAsync(IData _data, Model.Session.Session session, TableRequest? getTableRequest);
}
