﻿using System;
using System.Collections.Generic;
using MasjidOnline.Api.Model.Payment;
using Microsoft.AspNetCore.Http;

namespace MasjidOnline.Api.Model.Infaq;

public class AnonymInfaqRequest
{
    public required string MunfiqName { get; set; }

    public required decimal Amount { get; set; }

    public required PaymentType PaymentType { get; set; }

    public DateTime? ManualBankTransferDateTime { get; set; }

    public string? ManualBankTransferNotes { get; set; }

    public IEnumerable<IFormFile>? Files { get; set; }
}
