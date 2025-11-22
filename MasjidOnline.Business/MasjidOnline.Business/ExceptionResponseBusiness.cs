using System;
using MasjidOnline.Business.Interface;
using MasjidOnline.Business.Model.Responses;
using MasjidOnline.Library.Exceptions;

namespace MasjidOnline.Business;

public class ExceptionResponseBusiness : IExceptionResponseBusiness
{
    public virtual ExceptionResponse Build(Exception exception)
    {
        ExceptionResponse exceptionResponse;

        var exceptionType = exception.GetType();

        if (exceptionType == typeof(InputInvalidException))
        {
            exceptionResponse = new()
            {
                ResultCode = ResponseResultCode.InputInvalid,
                ResultMessage = exception.Message,
            };
        }
        else if (exceptionType == typeof(InputMismatchException))
        {
            exceptionResponse = new() { ResultCode = ResponseResultCode.InputMismatch };
        }
        else if (exceptionType == typeof(SessionExpireException))
        {
            exceptionResponse = new() { ResultCode = ResponseResultCode.SessionExpire };
        }
        else if (exceptionType == typeof(PermissionException))
        {
            exceptionResponse = new() { ResultCode = ResponseResultCode.PermissionMismatch };
        }
        else
        {
            exceptionResponse = new() { ResultCode = ResponseResultCode.Error };
        }

        return exceptionResponse;
    }
}
