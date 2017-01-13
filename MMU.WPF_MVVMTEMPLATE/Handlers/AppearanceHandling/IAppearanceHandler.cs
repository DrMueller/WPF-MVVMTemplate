using $safeprojectname$.Models.Shell.Enumerations;

namespace $safeprojectname$.Handlers.AppearanceHandling
{
    public interface IAppearanceHandler
    {
        AppearanceTheme LoadPersistedAppearanceTheme();

        void SetAndPersistAppearanceTheme(AppearanceTheme appearanceTheme);
    }
}