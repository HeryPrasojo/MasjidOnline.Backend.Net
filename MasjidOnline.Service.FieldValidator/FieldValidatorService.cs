﻿using System.Globalization;
using System.Runtime.CompilerServices;
using System.Text.RegularExpressions;
using MasjidOnline.Library.Exceptions;
using MasjidOnline.Service.FieldValidator.Interface;

namespace MasjidOnline.Service.FieldValidator;

public class FieldValidatorService : IFieldValidatorService
{
    public string? ValidateOptionalTextShort(string? value, [CallerArgumentExpression(nameof(value))] string? valueExpression = default)
    {
        if (value == default) return default;


        value = value.Trim();

        var length = value.Length;

        if (length == 0) return default;

        if (length > 255) throw new InputInvalidException(valueExpression);

        return value;
    }

    public void ValidateRequired(decimal? value, [CallerArgumentExpression(nameof(value))] string? valueExpression = default)
    {
        if (!value.HasValue) throw new InputInvalidException(valueExpression);

        if (value < 1m) throw new InputInvalidException(valueExpression);
    }

    public void ValidateRequired(Enum? value, [CallerArgumentExpression(nameof(value))] string? valueExpression = default)
    {
        if (value is null) throw new InputInvalidException(valueExpression);

        var valueType = value.GetType();

        if (!Enum.IsDefined(valueType, value)) throw new InputInvalidException(valueExpression);
    }

    public void ValidateRequired<TObject>(TObject? value, [CallerArgumentExpression(nameof(value))] string? valueExpression = default) where TObject : class
    {
        if (value == default) throw new InputInvalidException(valueExpression);
    }

    public void ValidateRequiredDateTimePast(DateTime? value, [CallerArgumentExpression(nameof(value))] string? valueExpression = default)
    {
        if (value == default) throw new InputInvalidException(valueExpression);

        if (value >= DateTime.UtcNow) throw new InputInvalidException(valueExpression);
    }

    public string ValidateRequiredEmailAddress(string? value, [CallerArgumentExpression(nameof(value))] string? valueExpression = default)
    {
        if (value == default) throw new InputInvalidException(valueExpression);

        try
        {
            value = Regex.Replace(
                value,
                @"(@)(.+)$",
                match =>
                {
                    var idn = new IdnMapping();

                    string domainName = idn.GetAscii(match.Groups[2].Value);

                    return match.Groups[1].Value + domainName;
                },
                RegexOptions.None,
                TimeSpan.FromMilliseconds(200));
        }
        catch (Exception exception)
        {
            throw new InputInvalidException(valueExpression, exception);
        }


        bool isMatch;

        try
        {
            isMatch = Regex.IsMatch(
                value,
                @"^[^@\s]+@[^@\s]+\.[^@\s]+$",
                RegexOptions.IgnoreCase,
                TimeSpan.FromMilliseconds(250));
        }
        catch (Exception exception)
        {
            throw new InputInvalidException(valueExpression, exception);
        }

        if (!isMatch) throw new InputInvalidException(valueExpression);

        return value;
    }

    public byte[] ValidateRequiredTextHex(string? value, int valueLength, [CallerArgumentExpression(nameof(value))] string? valueExpression = default)
    {
        if (value == default) throw new InputInvalidException(valueExpression);


        value = value.Trim();
        // undone 6
        var length = value.Length;

        if (length != valueLength) throw new InputInvalidException(valueExpression);

        try
        {
            return Convert.FromHexString(value);
        }
        catch (Exception exception)
        {
            throw new InputInvalidException(valueExpression, exception);
        }
    }

    public string ValidateRequiredTextShort(string? value, [CallerArgumentExpression(nameof(value))] string? valueExpression = default)
    {
        if (value == default) throw new InputInvalidException(valueExpression);


        value = value.Trim();

        var length = value.Length;

        if (length == 0 || length > 255) throw new InputInvalidException(valueExpression);

        return value;
    }
}
