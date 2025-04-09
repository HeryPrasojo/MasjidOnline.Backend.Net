using System;
using MasjidOnline.Business.Model;

namespace MasjidOnline.Business.Session.Interface.Model;

public class Session
{
    public Memory<byte> Digest { get; set; }

    public int Id { get; set; }

    public int UserId { get; set; }


    public bool IsUserAnonymous => UserId == Constant.UserId.Anonymous;
}
