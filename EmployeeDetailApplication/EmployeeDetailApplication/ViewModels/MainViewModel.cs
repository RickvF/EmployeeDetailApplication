using EmployeeDetailApplication.Commands;
using EmployeeDetailApplication.Models.Navigators;
using EmployeeDetailApplication.ViewModels.Factories;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;

namespace EmployeeDetailApplication.ViewModels
{
    public class MainViewModel : BaseViewModel
    {
        public INavigator Navigator { get; set; }

        public ICommand UpdateViewModelCommand { get; }

        private readonly IRootViewModelFactory _ViewModelFactory;

        public MainViewModel(INavigator navigator, IRootViewModelFactory viewModelFactory)
        {
            Navigator = navigator;
            _ViewModelFactory = viewModelFactory;
            UpdateViewModelCommand = new UpdateViewModelCommand(navigator, _ViewModelFactory);
            UpdateViewModelCommand.Execute(ViewType.Home);
        }
    }
}
