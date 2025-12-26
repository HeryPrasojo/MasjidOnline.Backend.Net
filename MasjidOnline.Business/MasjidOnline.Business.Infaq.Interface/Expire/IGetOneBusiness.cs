using System.Threading.Tasks;
using MasjidOnline.Business.Model.Infaq.Expire;
using MasjidOnline.Business.Model.Responses;
using MasjidOnline.Data.Interface;

namespace MasjidOnline.Business.Infaq.Interface.Expire;

public interface IGetOneBusiness
{
    Task<Response<GetOneResponse>> GetAsync(IData _data, GetOneRequest? getOneRequest);
}
