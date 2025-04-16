using System.Threading.Tasks;
using MasjidOnline.Business.Accountancy.Interface.Model.Expenditure;
using MasjidOnline.Data.Interface;

namespace MasjidOnline.Business.Accountancy.Interface.Expenditure;

public interface IGetOneBusiness
{
    Task<GetOneResponse> GetAsync(IData _data, GetOneRequest? getOneRequest);
}
