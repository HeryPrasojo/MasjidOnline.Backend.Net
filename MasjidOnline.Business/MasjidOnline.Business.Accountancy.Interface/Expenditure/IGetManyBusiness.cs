using System.Threading.Tasks;
using MasjidOnline.Business.Accountancy.Interface.Model.Expenditure;
using MasjidOnline.Business.Model.Responses;
using MasjidOnline.Data.Interface;

namespace MasjidOnline.Business.Accountancy.Interface.Expenditure;

public interface IGetManyBusiness
{
    Task<Response<GetManyResponse<GetManyResponseRecord>>> GetAsync(IData _data, Session.Interface.Model.Session session, GetManyRequest? getManyRequest);
}
