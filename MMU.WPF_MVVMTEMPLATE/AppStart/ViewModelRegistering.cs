using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Microsoft.Practices.Unity;
using $safeprojectname$.ViewModels.Shell;

namespace $safeprojectname$.AppStart
{
    internal static class ViewModelRegistering
    {
        internal static void RegisterViewModels(IUnityContainer uc)
        {
            var viewModelTypes = GetAllViewModelTypes();
            foreach (var vm in viewModelTypes)
            {
                uc.RegisterType(vm, new ContainerControlledLifetimeManager());
            }
        }

        private static IEnumerable<Type> GetAllViewModelTypes()
        {
            var viewModelBaseType = typeof(ViewModelBase);

            var assembly = typeof(ViewModelBase).GetTypeInfo().Assembly;
            var result = assembly.GetTypes().Where(f => viewModelBaseType.IsAssignableFrom(f) && !f.GetTypeInfo().IsAbstract);

            return result.ToList();
        }
    }
}