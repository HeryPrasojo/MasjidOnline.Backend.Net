using MasjidOnline.Business.Authorization.Interface.Accountancy;

namespace MasjidOnline.Business.Authorization.Interface;

public interface IAccountancyAuthorizationBusiness
{
    IExpenditureAuthorization Expenditure { get; }
}
