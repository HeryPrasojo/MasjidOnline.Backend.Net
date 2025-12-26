using System.Collections.Generic;
using MasjidOnline.Business.Model.Accountancy.Expenditure;

namespace MasjidOnline.Business.Mapper.Accountancy;

public class ExpenditureStatusMapper
{
    private static readonly Dictionary<ExpenditureStatus, Entity.Accountancy.ExpenditureStatus> _toEntities = new()
    {
        { ExpenditureStatus.Approve, Entity.Accountancy.ExpenditureStatus.Approve },
        { ExpenditureStatus.Cancel,  Entity.Accountancy.ExpenditureStatus.Cancel },
        { ExpenditureStatus.New,     Entity.Accountancy.ExpenditureStatus.New },
        { ExpenditureStatus.Reject,  Entity.Accountancy.ExpenditureStatus.Reject },
    };

    private static readonly Dictionary<Entity.Accountancy.ExpenditureStatus, ExpenditureStatus> _toModel = new()
    {
        { Entity.Accountancy.ExpenditureStatus.Approve, ExpenditureStatus.Approve },
        { Entity.Accountancy.ExpenditureStatus.Cancel,  ExpenditureStatus.Cancel },
        { Entity.Accountancy.ExpenditureStatus.New,     ExpenditureStatus.New },
        { Entity.Accountancy.ExpenditureStatus.Reject,  ExpenditureStatus.Reject },
    };

    public Entity.Accountancy.ExpenditureStatus this[ExpenditureStatus model]
    {
        get => _toEntities[model];
    }

    public ExpenditureStatus this[Entity.Accountancy.ExpenditureStatus entity]
    {
        get => _toModel[entity];
    }
}
