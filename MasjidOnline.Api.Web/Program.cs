using MasjidOnline.Api.Web;
using MasjidOnline.Business.Donation;
using MasjidOnline.Data.EntityFramework.SqLite;
using MasjidOnline.Service.Captcha;
using Microsoft.AspNetCore.Builder;

var webApplicationBuilder = WebApplication.CreateBuilder(args);

webApplicationBuilder.Services.AddCaptchaService();

webApplicationBuilder.Services.AddSqLiteEntityFrameworkDataAccess(webApplicationBuilder.Configuration);

webApplicationBuilder.Services.AddDonationBusiness();

var webApplication = webApplicationBuilder.Build();

//webApplication.UseHttpsRedirection();

webApplication.MapEndpoint();

webApplication.Run();
