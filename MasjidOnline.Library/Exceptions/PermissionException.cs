﻿using System;

namespace MasjidOnline.Library.Exceptions;

public class PermissionException : Exception
{
    public PermissionException(string? message) : base(message)
    {
    }

    public PermissionException(string? message, Exception? innerException) : base(message, innerException)
    {
    }
}
