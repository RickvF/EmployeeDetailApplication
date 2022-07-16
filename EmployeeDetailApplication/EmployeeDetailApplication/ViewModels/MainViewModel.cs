using EmployeeDetailApplication.Models.Navigators;
using System;
using System.Collections.Generic;
using System.Text;

namespace EmployeeDetailApplication.ViewModels
{
    public class MainViewModel : BaseViewModel
    {
        public INavigator Navigator { get; set; }
        public MainViewModel(INavigator navigator)
        {
            Navigator = navigator;
            Navigator.UpdateViewModelCommand.Execute(ViewType.Home);
        }
    }
}
