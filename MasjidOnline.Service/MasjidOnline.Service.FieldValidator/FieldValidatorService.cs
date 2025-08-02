using System;
using System.Globalization;
using System.Runtime.CompilerServices;
using System.Text.RegularExpressions;
using MasjidOnline.Library.Exceptions;
using MasjidOnline.Service.FieldValidator.Interface;

namespace MasjidOnline.Service.FieldValidator;

public class FieldValidatorService : IFieldValidatorService
{
    public DateTime? ValidateOptionalBirth(DateTime? value, [CallerArgumentExpression(nameof(value))] string? valueExpression = default)
    {
        if (!value.HasValue) return default;

        if (value.Value == default) throw new InputInvalidException(valueExpression);

        // hack move parameter to db setting
        if (value > DateTime.UtcNow.AddYears(-2)) throw new InputInvalidException(valueExpression);

        return value.Value;
    }

    public TEnum? ValidateOptionalEnum<TEnum>(TEnum? value, [CallerArgumentExpression(nameof(value))] string? valueExpression = default) where TEnum : struct, Enum
    {
        if (!value.HasValue) return default;

        var valueType = value.Value.GetType();

        if (!Enum.IsDefined(valueType, value)) throw new InputInvalidException(valueExpression);

        return value.Value;
    }

    public string? ValidateOptionalTextDb255(string? value, [CallerArgumentExpression(nameof(value))] string? valueExpression = default)
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

    public string ValidateRequired(string? value, [CallerArgumentExpression(nameof(value))] string? valueExpression = default)
    {
        if (value is null) throw new InputInvalidException(valueExpression);


        value = value.Trim();

        if (value.Length < 1) throw new InputInvalidException(valueExpression);

        return value;
    }

    public string ValidateRequired(string? value, int valueLength, [CallerArgumentExpression(nameof(value))] string? valueExpression = default)
    {
        if (value is null) throw new InputInvalidException(valueExpression);


        value = value.Trim();

        var length = value.Length;

        if (length != valueLength) throw new InputInvalidException(valueExpression);

        return value;
    }

    public string ValidateRequired(string? value, int valueMinimumLength, int valueMaximumLength, [CallerArgumentExpression(nameof(value))] string? valueExpression = default)
    {
        if (value is null) throw new InputInvalidException(valueExpression);


        value = value.Trim();

        var length = value.Length;

        if (length < valueMinimumLength) throw new InputInvalidException(valueExpression);

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

    public DateTime ValidateRequiredBirth(DateTime? value, [CallerArgumentExpression(nameof(value))] string? valueExpression = default)
    {
        if (!value.HasValue) throw new InputInvalidException(valueExpression);

        if (value.Value == default) throw new InputInvalidException(valueExpression);

        // hack move parameter to db setting
        if (value > DateTime.UtcNow.AddYears(-2)) throw new InputInvalidException(valueExpression);

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

    public TEnum ValidateRequiredEnum<TEnum>(TEnum? value, [CallerArgumentExpression(nameof(value))] string? valueExpression = default) where TEnum : struct, Enum
    {
        if (!value.HasValue) throw new InputInvalidException(valueExpression);

        var valueType = value.Value.GetType();

        if (!Enum.IsDefined(valueType, value)) throw new InputInvalidException(valueExpression);

        return value.Value;
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

        if (value.Value == default) throw new InputInvalidException(valueExpression);

        if (value >= DateTime.UtcNow) throw new InputInvalidException(valueExpression);

        return value.Value;
    }

    public string ValidateRequiredPassword(string? value, [CallerArgumentExpression(nameof(value))] string? valueExpression = default)
    {
        if (value == default) throw new InputInvalidException(valueExpression);


        var length = value.Length;

        if (length < 8) throw new InputInvalidException(valueExpression);


        var isDigitExists = false;
        var isLowerExists = false;
        var isSymbolExists = false;
        var isUpperExists = false;

        foreach (var v in value)
        {
            if (!isDigitExists)
            {
                if (char.IsNumber(v)) isDigitExists = true;
            }

            if (!isLowerExists)
            {
                if (char.IsLower(v)) isLowerExists = true;
            }

            if (!isSymbolExists)
            {
                if (char.IsSymbol(v)) isSymbolExists = true;
            }

            if (!isUpperExists)
            {
                if (char.IsUpper(v)) isUpperExists = true;
            }

            if (isDigitExists && isLowerExists && isSymbolExists && isUpperExists)
            {
                break;
            }
        }

        if (!isDigitExists || !isLowerExists || !isSymbolExists || !isUpperExists) throw new InputInvalidException(valueExpression);

        return value;
    }

    // hack validate prefix
    public string ValidateRequiredPhoneNumber(string? value, [CallerArgumentExpression(nameof(value))] string? valueExpression = default)
    {
        if (value == default) throw new InputInvalidException(valueExpression);


        value = value.Trim();

        var length = value.Length;

        if ((length < 9) || (length > 14)) throw new InputInvalidException(valueExpression);


        //if (value[0] != '+') throw new InputInvalidException(valueExpression);

        //for (var i = 1; i < length; i++)
        for (var i = 0; i < length; i++)
        {
            if (!char.IsDigit(value[i])) throw new InputInvalidException(valueExpression);
        }

        return value;
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

    public string ValidateRequiredTextDb255(string? value, [CallerArgumentExpression(nameof(value))] string? valueExpression = default)
    {
        if (value == default) throw new InputInvalidException(valueExpression);


        value = value.Trim();

        var length = value.Length;

        if (length == 0 || length > 255) throw new InputInvalidException(valueExpression);

        return ValidateRequired(value, 1, 255);
    }
}
