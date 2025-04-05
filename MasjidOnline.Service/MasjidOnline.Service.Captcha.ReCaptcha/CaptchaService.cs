using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using MasjidOnline.Service.Captcha.Interface;
using Microsoft.Extensions.Options;

namespace MasjidOnline.Service.Captcha.ReCaptcha;

public class CaptchaService(IOptionsMonitor<GoogleOptions> _optionsMonitor) : ICaptchaService
{
    // todo optimize
    public async Task<bool> VerifyAsync(string token, string action)
    {
        using var httpClient = new HttpClient();

        var request = new
        {
            @event = new
            {
                expectedAction = action,
                siteKey = "6LdSD_oqAAAAAOS497xVyGNjp5AAN-TpvCxk8b5R",
                token = token,
            },
        };

        //var serializeJsonSerializerOptions = new JsonSerializerOptions
        //{
        //    PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
        //    //Encoder = JavaScriptEncoder.UnsafeRelaxedJsonEscaping,
        //};

        //var serializedRequest = JsonSerializer.Serialize(request, serializeJsonSerializerOptions);
        var serializedRequest = JsonSerializer.Serialize(request);

        using var stringContent = new StringContent(serializedRequest, Encoding.UTF8, "application/json");

        using var httpResponseMessage = await httpClient.PostAsync(_optionsMonitor.CurrentValue.ReCaptchaAssessmentsUri, stringContent);

        //httpResponseMessage.EnsureSuccessStatusCode();

        var serializedResponse = await httpResponseMessage.Content.ReadAsStringAsync();

        var deserializeJsonSerializerOptions = new JsonSerializerOptions
        {
            PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
            //Encoder = JavaScriptEncoder.UnsafeRelaxedJsonEscaping,
        };

        var assessmentResponse = JsonSerializer.Deserialize<AssessmentResponse>(serializedResponse, deserializeJsonSerializerOptions);

        return assessmentResponse.RiskAnalysis.Score > 0.5f;
    }
}
