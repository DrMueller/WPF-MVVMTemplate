using System;
using Microsoft.Practices.Unity;
using $safeprojectname$.Infrastructure.Singletons;
using $safeprojectname$.Models.Shell;

namespace $safeprojectname$.ViewModels.Shell
{
    public class ViewModelFactory
    {
        private readonly IUnityContainer _unityContainer;

        public ViewModelFactory(IUnityContainer unityContainer)
        {
            _unityContainer = unityContainer;
        }

        internal ViewModelBase CreateViewModel<T>(ViewModelParameterCollection viewModelParameterCollection)
            where T : ViewModelBase
        {
            var result = _unityContainer.Resolve<T>();
            if (viewModelParameterCollection.HasValue)
            {
                result.InjectParameters(viewModelParameterCollection);
            }

            return result;
        }

        internal ViewModelBase CreateViewModel(Type viewModelType, ViewModelParameterCollection viewModelParameterCollection)
        {
            var viewModelBaseType = typeof(ViewModelBase);

            if (!viewModelBaseType.IsAssignableFrom(viewModelType))
            {
                throw new ArgumentException($"{viewModelType.Name} is not assignable from ViewModelBase.");
            }

            var result = (ViewModelBase)_unityContainer.Resolve(viewModelType);
            if (viewModelParameterCollection.HasValue)
            {
                result.InjectParameters(viewModelParameterCollection);
            }

            return result;
        }
    }
}