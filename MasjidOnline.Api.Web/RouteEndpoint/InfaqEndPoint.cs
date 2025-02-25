using System.Threading.Tasks;
using MasjidOnline.Business.Infaq.Interface;
using MasjidOnline.Business.Infaq.Interface.Model.Infaq;
using MasjidOnline.Business.Interface.Model.Responses;
using MasjidOnline.Business.Session.Interface;
using MasjidOnline.Data.Interface.Datas;

namespace MasjidOnline.Api.Web.RouteEndpoint;

internal static class InfaqEndPoint
{
    internal static async Task<Response> AddByAnonymAsync(
        IInfaqAddBusiness _infaqAddBusiness,
        ICaptchaData _captchaData,
        ISessionBusiness _sessionBusiness,
        IInfaqsData _infaqsData,
        AddByAnonymRequest addByAnonymRequest)
    {
        return await _infaqAddBusiness.AddByAnonymAsync(_captchaData, _sessionBusiness, _infaqsData, addByAnonymRequest);
    }

    internal static async Task<GetManyResponse<GetManyResponseRecord>> GetManyAsync(
        IInfaqGetBusiness _infaqGetBusiness,
        IInfaqsData _infaqsData,
        GetManyRequest getManyRequest)
    {
        return await _infaqGetBusiness.GetManyAsync(_infaqsData, getManyRequest);
    }

    internal static async Task<GetOneResponse> GetOneAsync(
        IInfaqGetBusiness _infaqGetBusiness,
        IInfaqsData _infaqsData,
        GetOneRequest getOneRequest)
    {
        return await _infaqGetBusiness.GetOneAsync(_infaqsData, getOneRequest);
    }

    internal static async Task<GetOneResponse> GetOneAsync(
        IInfaq _infaqGetBusiness,
        IInfaqsData _infaqsData,
        GetOneRequest getOneRequest)
    {
        return await _infaqGetBusiness.(_infaqsData, getOneRequest);
    }
}
