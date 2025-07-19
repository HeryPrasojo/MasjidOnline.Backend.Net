using System.Threading.Tasks;
using MasjidOnline.Data.Interface;

namespace MasjidOnline.Business.Authorization.Interface.Infaq;

public interface IInfaqAuthorization
{
    Task AuthorizeOnBehalfAddAync(Session.Interface.Model.Session session, IData _data);
}
