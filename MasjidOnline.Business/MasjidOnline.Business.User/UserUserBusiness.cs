﻿using MasjidOnline.Business.User.Interface;
using MasjidOnline.Business.User.Interface.User;
using MasjidOnline.Business.User.User;

namespace MasjidOnline.Business.User;

public class UserUserBusiness(
    //IOptionsMonitor<BusinessOptions> _optionsMonitor,
    //Authorization.Interface.IAuthorizationBusiness _authorizationBusiness,
    //Data.Interface.IIdGenerator _idGenerator,
    Service.Interface.IService _service
    ) : IUserUserBusiness
{
    public IAddRegisterBusiness AddRegister { get; } = new AddRegisterBusiness();
    public ILoginBusiness Login { get; } = new LoginBusiness(_service);
    public ISetPasswordBusiness SetPassword { get; } = new SetPasswordBusiness(_service);
}
