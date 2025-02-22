using MasjidOnline.Business.Infaq.Interface.Model.Infaq;
using MasjidOnline.Business.Interface.Model.Responses;
using MasjidOnline.Business.Session.Interface;
using MasjidOnline.Data.Interface.Datas;

namespace MasjidOnline.Business.Infaq.Interface;

public interface IInfaqAddBusiness
{
    Task<Response> AddByAnonymAsync(ICaptchaData _captchaData, ISessionBusiness _sessionBusiness, IInfaqsData _infaqsData, AddByAnonymRequest addByAnonymRequest);
}
