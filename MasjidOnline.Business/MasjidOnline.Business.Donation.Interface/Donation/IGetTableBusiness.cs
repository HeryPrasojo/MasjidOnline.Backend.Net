using System.Threading.Tasks;
using MasjidOnline.Business.Model.Donation.Donation;
using MasjidOnline.Business.Model.Responses;
using MasjidOnline.Data.Interface;

namespace MasjidOnline.Business.Donation.Interface.Donation;

public interface IGetTableBusiness
{
    Task<Response<TableResponse<TableResponseRecord>>> GetAsync(Model.Session.Session session, IData _data, TableRequest? getTableRequest);
}


