using System;
using MasjidOnline.Business.Model.Responses;

namespace MasjidOnline.Business.Interface;

public interface IExceptionResponseBusiness
{
    ExceptionResponse Build(Exception exception);
}
