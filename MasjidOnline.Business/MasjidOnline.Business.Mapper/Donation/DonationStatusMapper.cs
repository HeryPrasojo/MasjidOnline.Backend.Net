using System.Collections.Generic;
using MasjidOnline.Business.Model.Donation.Donation;

namespace MasjidOnline.Business.Mapper.Donation;

public class DonationStatusMapper
{
    private static readonly Dictionary<DonationStatus, Entity.Donation.DonationStatus> _toEntity = new()
    {
        { DonationStatus.Fail,           Entity.Donation.DonationStatus.Fail },
        { DonationStatus.FailRequest,    Entity.Donation.DonationStatus.FailRequest },
        { DonationStatus.New,            Entity.Donation.DonationStatus.New },
        { DonationStatus.RefundRequest,  Entity.Donation.DonationStatus.RefundRequest },
        { DonationStatus.Refund,         Entity.Donation.DonationStatus.Refund },
        { DonationStatus.Success,        Entity.Donation.DonationStatus.Success },
        { DonationStatus.SuccessRequest, Entity.Donation.DonationStatus.SuccessRequest },
    };

    private static readonly Dictionary<Entity.Donation.DonationStatus, DonationStatus> _toModel = new()
    {
        { Entity.Donation.DonationStatus.Fail,           DonationStatus.Fail },
        { Entity.Donation.DonationStatus.FailRequest,    DonationStatus.FailRequest },
        { Entity.Donation.DonationStatus.New,            DonationStatus.New },
        { Entity.Donation.DonationStatus.Refund,         DonationStatus.Refund },
        { Entity.Donation.DonationStatus.RefundRequest,  DonationStatus.RefundRequest },
        { Entity.Donation.DonationStatus.Success,        DonationStatus.Success },
        { Entity.Donation.DonationStatus.SuccessRequest, DonationStatus.SuccessRequest },
    };


    public Entity.Donation.DonationStatus this[DonationStatus model]
    {
        get => _toEntity[model];
    }

    public DonationStatus this[Entity.Donation.DonationStatus entity]
    {
        get => _toModel[entity];
    }
}


