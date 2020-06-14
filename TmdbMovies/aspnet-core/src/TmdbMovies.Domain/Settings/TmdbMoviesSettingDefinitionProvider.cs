using Volo.Abp.Settings;

namespace TmdbMovies.Settings
{
    public class TmdbMoviesSettingDefinitionProvider : SettingDefinitionProvider
    {
        public override void Define(ISettingDefinitionContext context)
        {
            //Define your own settings here. Example:
            //context.Add(new SettingDefinition(TmdbMoviesSettings.MySetting1));
        }
    }
}
