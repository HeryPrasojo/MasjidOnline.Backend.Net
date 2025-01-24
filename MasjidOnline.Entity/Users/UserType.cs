namespace MasjidOnline.Entity.Users;

public enum UserType
{
    None = 0,
    System = 11,
    Anonymous = 21, // todo add 1 anonym user and refer UserId to it.
    Internal = 31,
    External = 41,
}