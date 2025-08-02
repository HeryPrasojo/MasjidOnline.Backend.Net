using System;
using System.Linq;
using System.Threading.Tasks;
using MasjidOnline.Business.Authorization.Interface;
using MasjidOnline.Business.Infaq.Infaq.Mapper;
using MasjidOnline.Business.Infaq.Interface.Model.Infaq;
using MasjidOnline.Data.Interface;
using MasjidOnline.Entity.Infaq;
using MasjidOnline.Library.Exceptions;
using MasjidOnline.Service.Interface;

namespace MasjidOnline.Business.Infaq.Infaq;

public class AddByBehalf(IAuthorizationBusiness _authorizationBusiness, IService _service, IIdGenerator _idGenerator) : Add
{

    public async Task AddAsync(IData _data, Session.Interface.Model.Session session, AddByInternalRequest addByInternalRequest)
    {
        await _authorizationBusiness.Infaq.Infaq.AuthorizeOnBehalfAddAync(session, _data);


        addByInternalRequest = _service.FieldValidator.ValidateRequired(addByInternalRequest);

        addByInternalRequest.Amount = _service.FieldValidator.ValidateRequiredPlus(addByInternalRequest.Amount);
        addByInternalRequest.PaymentType = _service.FieldValidator.ValidateRequiredEnum(addByInternalRequest.PaymentType);
        addByInternalRequest.ManualDateTime = _service.FieldValidator.ValidateRequiredPast(addByInternalRequest.ManualDateTime);


        var paymentTypes = new Payment.Interface.Model.PaymentType[]
        {
            Payment.Interface.Model.PaymentType.Cash,
            Payment.Interface.Model.PaymentType.ManualBankTransfer,
        };

        if (!paymentTypes.Any(t => t == addByInternalRequest.PaymentType)) throw new InputInvalidException(nameof(addByInternalRequest.PaymentType));


        await _data.Transaction.BeginAsync(_data.Infaq, _data.Payment);

        var utcNow = DateTime.UtcNow;

        var infaq = new Entity.Infaq.Infaq
        {
            Id = _idGenerator.Infaq.InfaqId,
            Amount = addByInternalRequest.Amount.Value,
            DateTime = utcNow,
            Status = InfaqStatus.New,
            PaymentType = addByInternalRequest.PaymentType.Value.ToEntity(),
            UserId = session.UserId,
            MunfiqName = addByInternalRequest.MunfiqName,
        };

        await _data.Infaq.Infaq.AddAsync(infaq);


        var infaqManual = new InfaqManual
        {
            InfaqId = infaq.Id,
            DateTime = addByInternalRequest.ManualDateTime.Value,
            Notes = addByInternalRequest.ManualNotes,
        };

        await _data.Infaq.InfaqManual.AddAsync(infaqManual);

        await _data.Transaction.CommitAsync();


        //todo low undone
    }

}
