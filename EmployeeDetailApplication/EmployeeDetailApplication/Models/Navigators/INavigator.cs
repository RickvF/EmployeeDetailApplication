using EmployeeDetailApplication.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;

namespace EmployeeDetailApplication.Models.Navigators
{
    public enum ViewType
    {
        Home,
        Create,
        Edit
    }

    public interface INavigator
    {
        BaseViewModel CurrentViewModel { get; set; }
        ICommand UpdateViewModelCommand { get; }
    }
}
