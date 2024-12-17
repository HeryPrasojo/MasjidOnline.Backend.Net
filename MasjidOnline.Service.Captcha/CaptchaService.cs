using System;
using System.IO;
using MasjidOnline.Service.Captcha.Interface;
using MasjidOnline.Service.Captcha.Model;

namespace MasjidOnline.Service.Captcha;

public class CaptchaService : ICaptchaService
{
    private readonly byte[][] _captcha = [
        File.ReadAllBytes("captcha-1.png"),
        File.ReadAllBytes("captcha-2.png"),
        File.ReadAllBytes("captcha-3.png"),
        File.ReadAllBytes("captcha-4.png"),
        File.ReadAllBytes("captcha-5.png"),
        File.ReadAllBytes("captcha-6.png"),
        File.ReadAllBytes("captcha-7.png"),
        File.ReadAllBytes("captcha-8.png")
    ];

    private readonly float[] _degree = [0f, 45f, 90f, 135f, 180f, 225f, 270f, 315f];

    private readonly Random _random = new();

    public GenerateImageResponse GenerateImage()
    {
        var number = _random.Next(1, 8);

        var captcha = _captcha[number];

        return new GenerateImageResponse
        {
            Degree = _degree[number],
            Stream = new MemoryStream(captcha, false),
        };
    }
}
