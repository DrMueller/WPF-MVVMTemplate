using System;
using MaterialDesignThemes.Wpf;
using $safeprojectname$.Infrastructure.Helpers;
using $safeprojectname$.Models.Shell.Enumerations;

namespace $safeprojectname$.Handlers.AppearanceHandling.Implementation
{
    public class AppearanceHandler : IAppearanceHandler
    {
        private const string REGISTRY_KEY_APPEARANCETHEME = "AppearanceTheme";
        private static readonly PaletteHelper _paletteHelper = new PaletteHelper();

        public AppearanceTheme LoadPersistedAppearanceTheme()
        {
            var savedTheme = RegistryHelper.LoadFromCurrentUserApplicationRegistry(REGISTRY_KEY_APPEARANCETHEME);

            AppearanceTheme appearanceTheme = AppearanceTheme.Light;
            if (!string.IsNullOrEmpty(savedTheme))
            {
                appearanceTheme = (AppearanceTheme)Enum.Parse(typeof(AppearanceTheme), savedTheme);
            }

            return appearanceTheme;
        }

        public void SetAndPersistAppearanceTheme(AppearanceTheme appearanceTheme)
        {
            _paletteHelper.SetLightDark(appearanceTheme == AppearanceTheme.Dark);
            RegistryHelper.SaveIntoCurrentUserApplicationRegistry(REGISTRY_KEY_APPEARANCETHEME, appearanceTheme.ToString());
        }
    }
}