using System;
using System.IO;
using MasjidOnline.Service.Captcha.Interface.Model;

namespace MasjidOnline.Service.Captcha;

public class CaptchaService /*: ICaptchaService*/
{
    private readonly GenerateImageResult[] _generateImageResults =
    [
        new()
        {
            Degree = 0f,
            Stream = new MemoryStream(Resource.captcha_1),
        },
        new()
        {
            Degree = 45f,
            Stream = new MemoryStream(Resource.captcha_2),
        },
        new()
        {
            Degree = 90f,
            Stream = new MemoryStream(Resource.captcha_3),
        },
        new()
        {
            Degree = 135f,
            Stream = new MemoryStream(Resource.captcha_4),
        },
        new()
        {
            Degree = 180f,
            Stream = new MemoryStream(Resource.captcha_5),
        },
        new()
        {
            Degree = 225f,
            Stream = new MemoryStream(Resource.captcha_6),
        },
        new()
        {
            Degree = 270f,
            Stream = new MemoryStream(Resource.captcha_7),
        },
        new()
        {
            Degree = 315f,
            Stream = new MemoryStream(Resource.captcha_8),
        }
    ];

    private readonly Random _random = new();

    public GenerateImageResult GenerateImage(float degree)
    {
        return Array.Find(_generateImageResults, r => r.Degree == degree)!;
    }

    public GenerateImageResult GenerateRandomImage()
    {
        var number = _random.NextInt64() / 1152921504606846975;

        if (number < 0) number = -number;

        return _generateImageResults[number];
    }
}
