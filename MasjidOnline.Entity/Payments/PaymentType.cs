﻿namespace MasjidOnline.Entity.Payments;

public enum PaymentType
{
    None = 0,
    Cash = 11,
    ManualBankTransfer = 21,
    ManualGopay = 22,
    PurwantaraVirtualAccountBankTransfer = 31,
}
