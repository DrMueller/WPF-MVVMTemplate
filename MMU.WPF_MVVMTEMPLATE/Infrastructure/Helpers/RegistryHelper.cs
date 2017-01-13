using Microsoft.Win32;

namespace $safeprojectname$.Infrastructure.Helpers
{
    internal static class RegistryHelper
    {
        internal static string LoadFromCurrentUserApplicationRegistry(string keyName)
        {
            var regKey = GetCurrentUserApplicationRegistryKey();
            var result = (string)regKey.GetValue(keyName, string.Empty);

            return result;
        }

        internal static void SaveIntoCurrentUserApplicationRegistry(string keyName, string value)
        {
            var regKey = GetCurrentUserApplicationRegistryKey();
            regKey.SetValue(keyName, value);
            regKey.Close();
        }

        private static RegistryKey GetCurrentUserApplicationRegistryKey()
        {
            var assemblyName = typeof(RegistryHelper).Assembly.GetName().Name;
            var subKey = string.Concat("SOFTWARE", @"\", assemblyName);
            var result = Registry.CurrentUser.CreateSubKey(subKey);

            return result;
        }
    }
}