using MasjidOnline.Business.Interface;
using MasjidOnline.Business.Session.Interface.Model;
using MasjidOnline.Data.Interface;
using MasjidOnline.Library.Exceptions;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Localization;
using Microsoft.Extensions.DependencyInjection;

namespace MasjidOnline.Api.Web.WebApplicationExtension;

public static class LocalizationExtension
{
    internal static WebApplication UseLocalization(this WebApplication webApplication)
    {
        webApplication.UseRequestLocalization(requestLocalizationOptions =>
        {
            requestLocalizationOptions.ApplyCurrentCultureToResponseHeaders = true;

            requestLocalizationOptions.AddInitialRequestCultureProvider(new CustomRequestCultureProvider(async httpContext =>
            {
                var getQueryResult = httpContext.Request.Query.TryGetValue("culture", out var culture);

                if (getQueryResult && !string.IsNullOrWhiteSpace(culture))
                {
                    string cultureString = culture.ToString();

                    var session = httpContext.RequestServices.GetService<Session>() ?? throw new ErrorException($"get {nameof(Session)} failed");
                    var data = httpContext.RequestServices.GetService<IData>() ?? throw new ErrorException($"get {nameof(IData)} failed");
                    var business = httpContext.RequestServices.GetService<IBusiness>() ?? throw new ErrorException($"get {nameof(IBusiness)} failed");

                    var cultureResult = await business.User.UserPreference.SetApplicationCulture.SetAsync(data, session, cultureString);

                    return new ProviderCultureResult(cultureResult, cultureResult);
                }


                // todo check db: session, user


                // todo check http header


                // todo else return default

                return new ProviderCultureResult("", "");
            }));
        });

        return webApplication;
    }
}
