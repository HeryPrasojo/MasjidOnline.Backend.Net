using System.Threading.Tasks;
using MasjidOnline.Api.Model;
using MasjidOnline.Api.Model.Infaq;
using MasjidOnline.Business.Infaq.Interface;
using MasjidOnline.Data.Interface.Core;

namespace MasjidOnline.Business.Infaq;

public class AnonymInfaqBusiness(
    ICoreData _dataAccess) : IAnonymInfaqBusiness
{
    public async Task<AnonymInfaqResponse> DonateAsync(string? sessionId, AnonymInfaqRequest anonymInfaqRequest)
    {
        if (sessionId == default) return new()
        {
            ResultMessage = "sessionId == default",
            ResultCode = ResponseResult.InputInvalid,
        };

        //await _dataAccess.CaptchaQuestionRepository.AddAsync(captchaQuestion);


        //var generateImageResponse = _captchaService.GenerateImage();


        //var captchaQuestion = new CaptchaQuestion
        //{
        //    CreateDateTime = DateTime.UtcNow,
        //    Degree = generateImageResponse.Degree,
        //    SessionId = sessionId,
        //};

        //await _dataAccess.CaptchaQuestionRepository.AddAsync(captchaQuestion);

        //var changed = await _dataAccess.SaveAsync();

        //if (changed != 1) return new()
        //{
        //    Message = "Data save failed",
        //    Result = ResponseResult.Error,
        //};

        return new()
        {
            ResultCode = ResponseResult.Success,
            SessionId = sessionId,
        };
        // todo
    }
}
