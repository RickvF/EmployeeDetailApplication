using EmployeeDetailApplication.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace EmployeeDetailApplication.ViewModels
{
    //Delegate function definition to create ViewModels in the RootViewModelFactory
    public delegate BaseViewModel CreateViewModel<BaseViewModel>();

    public class BaseViewModel : ObservableObject
    {
    }
}
