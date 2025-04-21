using System;
using System.Globalization;
using System.Runtime.CompilerServices;
using System.Text.RegularExpressions;
using MasjidOnline.Library.Exceptions;
using MasjidOnline.Service.FieldValidator.Interface;

namespace MasjidOnline.Service.FieldValidator;

public class FieldValidatorService : IFieldValidatorService
{
    public string? ValidateOptionalText255(string? value, [CallerArgumentExpression(nameof(value))] string? valueExpression = default)
    {
        if (value == default) return default;


        value = value.Trim();

        var length = value.Length;

        if (length == 0) return default;

        if (length > 255) throw new InputInvalidException(valueExpression);

        return value;
    }

    public TObject ValidateRequired<TObject>(TObject? value, [CallerArgumentExpression(nameof(value))] string? valueExpression = default) where TObject : class
    {
        if (value == default) throw new InputInvalidException(valueExpression);

        return value;
    }

    public Enum ValidateRequired(Enum? value, [CallerArgumentExpression(nameof(value))] string? valueExpression = default)
    {
        if (value is null) throw new InputInvalidException(valueExpression);

        var valueType = value.GetType();

        if (!Enum.IsDefined(valueType, value)) throw new InputInvalidException(valueExpression);

        return value;
    }

    public string ValidateRequired(string? value, int valueMaximumLength, [CallerArgumentExpression(nameof(value))] string? valueExpression = default)
    {
        if (value is null) throw new InputInvalidException(valueExpression);


        value = value.Trim();

        var length = value.Length;

        if (length == 0) throw new InputInvalidException(valueExpression);

        if (length > valueMaximumLength) throw new InputInvalidException(valueExpression);

        return value;
    }

    public byte[] ValidateRequiredBase64(string? value, int valueLength, [CallerArgumentExpression(nameof(value))] string? valueExpression = default)
    {
        if (value == default) throw new InputInvalidException(valueExpression);


        value = value.Trim();

        if (value.Length != valueLength) throw new InputInvalidException(valueExpression);


        try
        {
            return Convert.FromBase64String(value);
        }
        catch (Exception exception)
        {
            throw new InputInvalidException(valueExpression, exception);
        }
    }

    public byte[] ValidateRequiredHex(string? value, int valueLength, [CallerArgumentExpression(nameof(value))] string? valueExpression = default)
    {
        if (value == default) throw new InputInvalidException(valueExpression);


        value = value.Trim();

        if (value.Length != valueLength) throw new InputInvalidException(valueExpression);


        try
        {
            return Convert.FromHexString(value);
        }
        catch (Exception exception)
        {
            throw new InputInvalidException(valueExpression, exception);
        }
    }

    public DateTime ValidateRequiredPast(DateTime? value, [CallerArgumentExpression(nameof(value))] string? valueExpression = default)
    {
        if (!value.HasValue) throw new InputInvalidException(valueExpression);

        if (value >= DateTime.UtcNow) throw new InputInvalidException(valueExpression);

        return value.Value;
    }

    public decimal ValidateRequiredPlus(decimal? value, [CallerArgumentExpression(nameof(value))] string? valueExpression = default)
    {
        if (!value.HasValue) throw new InputInvalidException(valueExpression);

        if (value < 1m) throw new InputInvalidException(valueExpression);

        return value.Value;
    }

    public int ValidateRequiredPlus(int? value, [CallerArgumentExpression(nameof(value))] string? valueExpression = default)
    {
        if (!value.HasValue) throw new InputInvalidException(valueExpression);

        if (value < 1) throw new InputInvalidException(valueExpression);

        return value.Value;
    }

    public string ValidateRequiredEmailAddress(string? value, [CallerArgumentExpression(nameof(value))] string? valueExpression = default)
    {
        if (value == default) throw new InputInvalidException(valueExpression);


        value = value.Trim();

        if (value.Length > 254) throw new InputInvalidException(valueExpression);

        value = value.ToLowerInvariant();

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
                RegexOptions.None,
                TimeSpan.FromMilliseconds(250));
        }
        catch (Exception exception)
        {
            throw new InputInvalidException(valueExpression, exception);
        }

        if (!isMatch) throw new InputInvalidException(valueExpression);

        return value;
    }

    public string ValidateRequiredText255(string? value, [CallerArgumentExpression(nameof(value))] string? valueExpression = default)
    {
        if (value == default) throw new InputInvalidException(valueExpression);


        value = value.Trim();

        var length = value.Length;

        if (length == 0 || length > 255) throw new InputInvalidException(valueExpression);

        return value;
    }
}
