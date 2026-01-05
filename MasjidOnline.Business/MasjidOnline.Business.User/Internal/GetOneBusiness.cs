using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MasjidOnline.Business.Model.Responses;
using MasjidOnline.Business.Model.User.Internal;
using MasjidOnline.Business.User.Interface.Internal;
using MasjidOnline.Data.Interface;
using MasjidOnline.Library.Exceptions;
using MasjidOnline.Service.Interface;

namespace MasjidOnline.Business.User.Internal;

public class GetOneBusiness(IService _service) : IGetOneBusiness
{
    public async Task<Response<GetOneResponse>> GetAsync(
        Model.Session.Session session,
        IData _data,
        GetOneRequest? getOneRequest)
    {
        getOneRequest = _service.FieldValidator.ValidateRequired(getOneRequest);
        getOneRequest.Id = _service.FieldValidator.ValidateRequiredPlus(getOneRequest.Id);


        var internalUser = await _data.User.InternalUser.GetOneAsync(getOneRequest.Id.Value)
            ?? throw new InputMismatchException($"{nameof(getOneRequest.Id)}: {getOneRequest.Id}");


        var userIds = new List<int>
        {
            internalUser.AddUserId,
            internalUser.UserId,
        };

        if (internalUser.UpdateUserId.HasValue) userIds.Add(internalUser.UpdateUserId.Value);

        var userDatas = await _data.User.UserData.GetForOneInternalUserAsync(userIds)
            ?? throw new DataMismatchException(nameof(userIds));


        var userEmailIds = new List<int>();

        var userData = userDatas.FirstOrDefault(e => e.UserId == internalUser.UserId)
            ?? throw new DataMismatchException(nameof(internalUser.UserId));

        var addUserData = userDatas.FirstOrDefault(e => e.UserId == internalUser.AddUserId)
            ?? throw new DataMismatchException(nameof(internalUser.AddUserId));

        var updateUserData = internalUser.UpdateUserId.HasValue
            ? userDatas.FirstOrDefault(e => e.UserId == internalUser.UpdateUserId)
                ?? throw new DataMismatchException(nameof(internalUser.UpdateUserId))
            : default;


        if (userData.MainContactType == Entity.User.ContactType.Email) userEmailIds.Add(userData.MainContactId);
        else throw new DataMismatchException(nameof(userData.MainContactType));

        if (addUserData.MainContactType == Entity.User.ContactType.Email) userEmailIds.Add(addUserData.MainContactId);
        else throw new DataMismatchException(nameof(addUserData.MainContactType));

        if (updateUserData != default)
        {
            if (updateUserData.MainContactType == Entity.User.ContactType.Email) userEmailIds.Add(updateUserData.MainContactId);
            else throw new DataMismatchException(nameof(updateUserData.MainContactType));
        }


        var persons = await _data.Person.Person.GetForOneInternalUserAsync(userIds)
            ?? throw new DataMismatchException(nameof(userIds));

        var person = persons.FirstOrDefault(e => e.UserId == internalUser.UserId)
            ?? throw new DataMismatchException(nameof(internalUser.UserId));

        var addPerson = persons.FirstOrDefault(e => e.UserId == internalUser.AddUserId)
            ?? throw new DataMismatchException(nameof(internalUser.AddUserId));

        var editPerson = internalUser.UpdateUserId.HasValue
            ? persons.FirstOrDefault(e => e.UserId == internalUser.UpdateUserId)
                ?? throw new DataMismatchException(nameof(internalUser.UpdateUserId))
            : default;


        var status = Mapper.Mapper.User.InternalUserStatus[internalUser.Status];

        if (!session.IsUserAnonymous)
        {
            var userType = await _data.User.User.GetTypeAsync(session.UserId);

            if (userType == Entity.User.UserType.Internal)
            {
                string? contact = default;
                string? addContact = default;
                string? editContact = default;

                Entity.User.ContactType contactType = default;
                Entity.User.ContactType addContactType = default;
                Entity.User.ContactType? editContactType = default;

                if (userEmailIds.Count > 0)
                {
                    var userEmails = await _data.User.UserEmail.GetForOneInternalUserAsync(userEmailIds)
                        ?? throw new DataMismatchException(nameof(userEmailIds));


                    var userEmail = userEmails.FirstOrDefault(e => e.Id == userData.MainContactId);

                    if (userEmail != default)
                    {
                        contact = userEmail.Address;
                        contactType = Entity.User.ContactType.Email;
                    }


                    var addUserEmail = userEmails.FirstOrDefault(e => e.Id == addUserData.MainContactId);

                    if (addUserEmail != default)
                    {
                        addContact = addUserEmail.Address;
                        addContactType = Entity.User.ContactType.Email;
                    }


                    if (updateUserData != default)
                    {
                        var updateUserEmail = userEmails.FirstOrDefault(e => e.Id == updateUserData.MainContactId);

                        if (updateUserEmail != default)
                        {
                            editContact = updateUserEmail.Address;
                            editContactType = Entity.User.ContactType.Email;
                        }
                    }
                }

                if (contactType == default) throw new DataMismatchException(nameof(contactType));
                if (addContactType == default) throw new DataMismatchException(nameof(addContactType));

                return new()
                {
                    ResultCode = ResponseResultCode.Success,
                    Data = new()
                    {
                        AddContact = addContact ?? throw new DataMismatchException(nameof(addContact)),
                        AddContactType = _service.Localization[Mapper.Mapper.User.ContactType[addContactType], session.CultureInfo],
                        AddPersonName = addPerson.Name,
                        Contact = contact ?? throw new DataMismatchException(nameof(contact)),
                        ContactType = _service.Localization[Mapper.Mapper.User.ContactType[contactType], session.CultureInfo],
                        DateTime = _service.Localization[internalUser.DateTime, session.CultureInfo, "yyyy MMM d, HH:mm"],
                        Description = internalUser.Description,
                        EditDateTime = _service.Localization[internalUser.UpdateDateTime, session.CultureInfo, "yyyy MMM d, HH:mm"],
                        EditContact = editContact,
                        EditContactType = editContactType.HasValue
                            ? _service.Localization[Mapper.Mapper.User.ContactType[editContactType.Value], session.CultureInfo]
                            : default,
                        EditPersonName = editPerson?.Name,
                        PersonName = person.Name,
                        Status = status,
                        StatusText = _service.Localization[status, session.CultureInfo],
                    },
                };
            }
        }

        return new()
        {
            ResultCode = ResponseResultCode.Success,
            Data = new()
            {
                AddPersonName = addPerson.Name,
                DateTime = _service.Localization[internalUser.DateTime, session.CultureInfo, "yyyy MMM d, HH:mm"],
                Description = internalUser.Description,
                EditDateTime = _service.Localization[internalUser.UpdateDateTime, session.CultureInfo, "yyyy MMM d, HH:mm"],
                EditPersonName = editPerson?.Name,
                PersonName = person.Name,
                Status = status,
                StatusText = _service.Localization[Mapper.Mapper.User.InternalUserStatus[internalUser.Status], session.CultureInfo],
            },
        };
    }
}
