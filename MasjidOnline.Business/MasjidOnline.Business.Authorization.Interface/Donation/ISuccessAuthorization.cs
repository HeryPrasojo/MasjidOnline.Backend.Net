using System.Threading.Tasks;
using MasjidOnline.Data.Interface;

namespace MasjidOnline.Business.Authorization.Interface.Donation;

public interface ISuccessAuthorization
{
    Task AuthorizeAddAync(Model.Session.Session session, IData _data);
    Task AuthorizeApproveAync(Model.Session.Session session, IData _data);
}

