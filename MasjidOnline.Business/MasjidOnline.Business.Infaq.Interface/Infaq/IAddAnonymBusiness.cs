using MasjidOnline.Business.Infaq.Interface.Model.Infaq;
using MasjidOnline.Business.Interface.Model.Responses;
using MasjidOnline.Business.Session.Interface;
using MasjidOnline.Data.Interface.Databases;

namespace MasjidOnline.Business.Infaq.Interface.Infaq;

public interface IAddAnonymBusiness
{
    Task<Response> AddAsync(ICaptchaDatabase _captchaDatabase, ISessionBusiness _sessionBusiness, IInfaqDatabase _infaqDatabase, AddByAnonymRequest? addByAnonymRequest);
}
