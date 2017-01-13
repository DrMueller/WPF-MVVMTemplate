using Microsoft.Practices.Unity;

namespace $safeprojectname$.Infrastructure.Singletons
{
    internal class UnityContainerInstance
    {
        internal static UnityContainer Instance { get; private set; }

        internal static void Initialize(UnityContainer unityContainer)
        {
            Instance = unityContainer;
        }
    }
}
