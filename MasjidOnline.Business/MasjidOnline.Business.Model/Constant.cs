﻿namespace MasjidOnline.Business.Model;

public static class Constant
{
    public const string SystemUserEmailAddress = "system@masjidonline.org";

    public static class Path
    {
        public const string InfaqFileDirectory = "..\\..\\file\\infaq\\";
    }

    public static class UserId
    {
        public const int Anonymous = 1;
        public const int System = 2;
        public const int Root = 3;
    }
}
