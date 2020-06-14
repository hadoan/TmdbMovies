using TmdbMovies.Localization;
using Volo.Abp.Authorization.Permissions;
using Volo.Abp.Localization;

namespace TmdbMovies.Permissions
{
    public class TmdbMoviesPermissionDefinitionProvider : PermissionDefinitionProvider
    {
        public override void Define(IPermissionDefinitionContext context)
        {
            var myGroup = context.AddGroup(TmdbMoviesPermissions.GroupName);


            var moviePermission = myGroup.AddPermission(TmdbMoviesPermissions.Movies.Default, L("Permission:Movies"));
            moviePermission.AddChild(TmdbMoviesPermissions.Movies.Create, L("Permission:Create"));
            moviePermission.AddChild(TmdbMoviesPermissions.Movies.Edit, L("Permission:Edit"));
            moviePermission.AddChild(TmdbMoviesPermissions.Movies.Delete, L("Permission:Delete"));
        }

        private static LocalizableString L(string name)
        {
            return LocalizableString.Create<TmdbMoviesResource>(name);
        }
    }
}
