namespace TmdbMovies.Permissions
{
    public static class TmdbMoviesPermissions
    {
        public const string GroupName = "TmdbMovies";

        //Add your own permission names. Example:
        //public const string MyPermission1 = GroupName + ".MyPermission1";

        public class Movies
        {
            public const string Default = GroupName + ".Movies";
            public const string Edit = Default + ".Edit";
            public const string Create = Default + ".Create";
            public const string Delete = Default + ".Delete";
        }
    }
}