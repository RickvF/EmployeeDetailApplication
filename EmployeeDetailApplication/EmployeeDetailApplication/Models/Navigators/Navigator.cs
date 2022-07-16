using EmployeeDetailApplication.Commands;
using EmployeeDetailApplication.ViewModels;
using EmployeeDetailApplication.ViewModels.Factories;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;

namespace EmployeeDetailApplication.Models.Navigators
{
    public class Navigator : ObservableObject, INavigator
    {
        private BaseViewModel _baseViewModel;
        public BaseViewModel CurrentViewModel
        {
            get
            {
                return _baseViewModel;
            }
            set
            {
                _baseViewModel = value;
                OnPropertyChanged(nameof(CurrentViewModel));
            }
        }

        public ICommand UpdateViewModelCommand { get; set; }

        public Navigator(IRootViewModelFactory viewModelFactory)
        {
            UpdateViewModelCommand = new UpdateViewModelCommand(this, viewModelFactory);
        }
    }
}
