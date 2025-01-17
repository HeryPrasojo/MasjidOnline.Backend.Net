﻿using System.Threading.Tasks;
using MasjidOnline.Api.Model.Captcha;

namespace MasjidOnline.Business.Captcha.Interface;

public interface ICaptchaQuestionBusiness
{
    Task<CreateQuestionResponse> CreateAsync(byte[]? sessionId);
}
