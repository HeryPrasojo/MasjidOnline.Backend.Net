namespace MasjidOnline.Business.Mapper.Verification;

public class ContactTypeMapper
{
    private static readonly Dictionary<Entity.Verification.ContactType, Model.Verification.ContactType> _toModel = new()
    {
        { Entity.Verification.ContactType.Email, Model.Verification.ContactType.Email },
    };

    private static readonly Dictionary<Model.Verification.ContactType, Entity.Verification.ContactType> _toEntity = new()
    {
        { Model.Verification.ContactType.Email, Entity.Verification.ContactType.Email },
    };


    public Entity.Verification.ContactType this[Model.Verification.ContactType contactType]
    {
        get => _toEntity[contactType];
    }

    public Model.Verification.ContactType this[Entity.Verification.ContactType contactType]
    {
        get => _toModel[contactType];
    }
}
