using System;
using PropertyChanged;
using $safeprojectname$.Models.Shell;

namespace $safeprojectname$.ViewModels.Shell
{
    [ImplementPropertyChanged]
    public abstract class ViewModelBase
    {
    public abstract string DisplayName { get; }

    public virtual void InjectParameters(ViewModelParameterCollection viewModelParameterCollection)
    {
        throw new NotImplementedException($"ViewModel {GetType().Name} does not accept Parameters.");
    }
}
}