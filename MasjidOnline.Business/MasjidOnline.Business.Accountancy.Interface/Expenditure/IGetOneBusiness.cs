using System.Threading.Tasks;
using MasjidOnline.Business.Model.Accountancy.Expenditure;
using MasjidOnline.Business.Model.Responses;
using MasjidOnline.Data.Interface;

namespace MasjidOnline.Business.Accountancy.Interface.Expenditure;

public interface IGetOneBusiness
{
    Task<Response<GetOneResponse>> GetAsync(IData _data, GetOneRequest? getOneRequest);
}
