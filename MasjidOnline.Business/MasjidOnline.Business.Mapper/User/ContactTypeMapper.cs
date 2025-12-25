using System.Collections.Generic;
using MasjidOnline.Business.User.Interface.Model.User;

namespace MasjidOnline.Business.Mapper.User;

public class ContactTypeMapper
{
    private static readonly Dictionary<Entity.User.ContactType, ContactType> _toModel = new()
    {
        { Entity.User.ContactType.Email, ContactType.Email },
    };

    private static readonly Dictionary<ContactType, Entity.User.ContactType> _toEntity = new()
    {
        { ContactType.Email, Entity.User.ContactType.Email },
    };


    public Entity.User.ContactType this[ContactType contactType]
    {
        get => _toEntity[contactType];
    }

    public ContactType this[Entity.User.ContactType contactType]
    {
        get => _toModel[contactType];
    }
}
