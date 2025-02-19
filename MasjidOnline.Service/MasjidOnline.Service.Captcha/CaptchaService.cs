using System;
using System.IO;
using MasjidOnline.Service.Captcha.Interface;
using MasjidOnline.Service.Captcha.Interface.Model;

namespace MasjidOnline.Service.Captcha;

public class CaptchaService : ICaptchaService
{
    private readonly byte[][] _captcha = [
        Resource.captcha_1,
        Resource.captcha_2,
        Resource.captcha_3,
        Resource.captcha_4,
        Resource.captcha_5,
        Resource.captcha_6,
        Resource.captcha_7,
        Resource.captcha_8,
    ];

    private readonly float[] _degree = [0f, 45f, 90f, 135f, 180f, 225f, 270f, 315f];

    private readonly Random _random = new();

    public GenerateImageResult GenerateImage(float degree)
    {
        var index = Array.IndexOf(_degree, degree);

        return new GenerateImageResult
        {
            Degree = _degree[index],
            Stream = new MemoryStream(_captcha[index]),
        };
    }

    public GenerateImageResult GenerateRandomImage()
    {
        var number = _random.Next(1, 8);

        return new GenerateImageResult
        {
            Degree = _degree[number],
            Stream = new MemoryStream(_captcha[number]),
        };
    }
}
