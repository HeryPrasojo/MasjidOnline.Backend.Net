using MasjidOnline.Business.Infaq.Interface.Model.Infaq;
using MasjidOnline.Business.Interface.Model.Responses;
using MasjidOnline.Business.Session.Interface;
using MasjidOnline.Data.Interface.Datas;

namespace MasjidOnline.Business.Infaq.Interface.Infaq;

public interface IAddAnonymBusiness
{
    Task<Response> AddAsync(ICaptchaData _captchaData, ISessionBusiness _sessionBusiness, IInfaqData _infaqData, AddByAnonymRequest addByAnonymRequest);
}
