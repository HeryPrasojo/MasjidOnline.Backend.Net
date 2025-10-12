using System;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using MasjidOnline.Library.Exceptions;
using MasjidOnline.Library.Extensions;
using MasjidOnline.Service.Captcha.Interface;
using Microsoft.Extensions.Options;

namespace MasjidOnline.Service.Captcha.ReCaptcha;

public class CaptchaService(IHttpClientFactory _httpClientFactory, IOptionsMonitor<GoogleOptions> _optionsMonitor) : ICaptchaService
{
    private static readonly JsonSerializerOptions _jsonSerializerOptions = new()
    {
        PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
    };

    private static readonly string _serializedRequest = JsonSerializer.Serialize(
        new
        {
            Event = new
            {
                ExpectedAction = "[action]",
                SiteKey = "6LdSD_oqAAAAAOS497xVyGNjp5AAN-TpvCxk8b5R",
                Token = "[token]",
            },
        },
        _jsonSerializerOptions);

    private static readonly JsonSerializerOptions _deserializeJsonSerializerOptions = new()
    {
        PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
        //Encoder = JavaScriptEncoder.UnsafeRelaxedJsonEscaping,
    };

    public void Initialize()
    {
        if (_optionsMonitor.CurrentValue.ReCaptcha.ActionAffix.IsNullOrEmptyOrWhiteSpace())
            throw new Exception($"{nameof(_optionsMonitor.CurrentValue.ReCaptcha.ActionAffix)} IsNullOrEmptyOrWhiteSpace");
    }

    public async Task<bool> VerifyAsync(string token, string action)
    {
        disable on development environment;
        var httpClient = _httpClientFactory.CreateClient(Constant.HttpClientName);

        var serializedRequest = _serializedRequest
            .Replace("[action]", action + _optionsMonitor.CurrentValue.ReCaptcha.ActionAffix)
            .Replace("[token]", token);

        using var stringContent = new StringContent(serializedRequest, Encoding.UTF8, "application/json");

        using var httpResponseMessage = await httpClient.PostAsync(_optionsMonitor.CurrentValue.ReCaptcha.AssessmentsUri, stringContent);

        httpResponseMessage.EnsureSuccessStatusCode();

        var serializedResponse = await httpResponseMessage.Content.ReadAsStringAsync();

        var assessmentResponse = JsonSerializer.Deserialize<AssessmentResponse>(serializedResponse, _deserializeJsonSerializerOptions);

        if (assessmentResponse == default) throw new ErrorException(serializedResponse);

        return assessmentResponse.RiskAnalysis.Score > 0.5f;
    }
}
