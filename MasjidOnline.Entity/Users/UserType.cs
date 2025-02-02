namespace MasjidOnline.Entity.Users;

public enum UserType
{
    Anonymous = 0, // todo add 1 anonym user and refer UserId to it.
    Root = 11,
    Internal = 31,
    External = 41,
}