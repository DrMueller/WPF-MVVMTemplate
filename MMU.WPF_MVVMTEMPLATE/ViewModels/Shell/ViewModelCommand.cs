using System.Windows.Input;

namespace $safeprojectname$.ViewModels.Shell
{
    public class ViewModelCommand
    {
        #region Constructors

        public ViewModelCommand(string description, ICommand command)
        {
            Description = description;
            Command = command;
        }

        #endregion Constructors

        #region Properties

        public ICommand Command { get; private set; }

        public string Description { get; private set; }

        #endregion Properties
    }
}
