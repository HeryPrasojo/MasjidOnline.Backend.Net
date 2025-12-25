using System.Threading.Tasks;
using MasjidOnline.Business.Infaq.Interface.Model.Void;
using MasjidOnline.Business.Model.Responses;
using MasjidOnline.Data.Interface;

namespace MasjidOnline.Business.Infaq.Interface.Void;

public interface IGetOneBusiness
{
    Task<Response<GetOneResponse>> GetAsync(IData _data, GetOneRequest? getOneRequest);
}
