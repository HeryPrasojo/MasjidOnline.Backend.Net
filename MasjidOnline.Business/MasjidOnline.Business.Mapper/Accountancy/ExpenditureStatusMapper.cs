using System.Collections.Generic;

namespace MasjidOnline.Business.Mapper.Accountancy;

public class ExpenditureStatusMapper
{
    private static readonly Dictionary<Business.Accountancy.Interface.Model.Expenditure.ExpenditureStatus, Entity.Accountancy.ExpenditureStatus> _toEntities = new()
    {
        { Business.Accountancy.Interface.Model.Expenditure.ExpenditureStatus.Approve, Entity.Accountancy.ExpenditureStatus.Approve },
        { Business.Accountancy.Interface.Model.Expenditure.ExpenditureStatus.Cancel,  Entity.Accountancy.ExpenditureStatus.Cancel },
        { Business.Accountancy.Interface.Model.Expenditure.ExpenditureStatus.New,     Entity.Accountancy.ExpenditureStatus.New },
        { Business.Accountancy.Interface.Model.Expenditure.ExpenditureStatus.Reject,  Entity.Accountancy.ExpenditureStatus.Reject },
    };

    private static readonly Dictionary<Entity.Accountancy.ExpenditureStatus, Business.Accountancy.Interface.Model.Expenditure.ExpenditureStatus> _toModel = new()
    {
        { Entity.Accountancy.ExpenditureStatus.Approve, Business.Accountancy.Interface.Model.Expenditure.ExpenditureStatus.Approve },
        { Entity.Accountancy.ExpenditureStatus.Cancel,  Business.Accountancy.Interface.Model.Expenditure.ExpenditureStatus.Cancel },
        { Entity.Accountancy.ExpenditureStatus.New,     Business.Accountancy.Interface.Model.Expenditure.ExpenditureStatus.New },
        { Entity.Accountancy.ExpenditureStatus.Reject,  Business.Accountancy.Interface.Model.Expenditure.ExpenditureStatus.Reject },
    };

    public Entity.Accountancy.ExpenditureStatus this[Business.Accountancy.Interface.Model.Expenditure.ExpenditureStatus model]
    {
        get => _toEntities[model];
    }

    public Business.Accountancy.Interface.Model.Expenditure.ExpenditureStatus this[Entity.Accountancy.ExpenditureStatus entity]
    {
        get => _toModel[entity];
    }
}
