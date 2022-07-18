using EmployeeDetailApplication.Models.Navigators;
using EmployeeDetailApplication.ViewModels.Factories;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;

namespace EmployeeDetailApplication.Commands
{
    //Command to update the ViewModel, update the active View. Used in the Navbar for navigation
    public class UpdateViewModelCommand : ICommand
    {
        public event EventHandler CanExecuteChanged;

        private readonly INavigator _navigator;
        private readonly IRootViewModelFactory _viewModelFactory;

        public UpdateViewModelCommand(INavigator navigator, IRootViewModelFactory viewModelFactory)
        {
            _navigator = navigator;
            _viewModelFactory = viewModelFactory;
        }

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            if(parameter is ViewType)
            {
                ViewType viewType = (ViewType)parameter;
                _navigator.CurrentViewModel = _viewModelFactory.CreateViewModel(viewType);
            }
        }
    }
}
