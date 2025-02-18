using MasjidOnline.Business.Infaq.Interface.Model;
using MasjidOnline.Business.Interface.Model.Responses;
using MasjidOnline.Business.Session.Interface;
using MasjidOnline.Data.Interface.Datas;

namespace MasjidOnline.Business.Infaq.Interface;

public interface IAnonymInfaqBusiness
{
    Task<Response> InfaqAsync(ICaptchaData _captchaData, ISessionBusiness _sessionBusiness, IInfaqsData _infaqsData, AnonymInfaqRequest anonymInfaqRequest);
}
