using EmployeeDetailApplication.Models;
using EmployeeDetailApplication.Services;
using System;
using System.Collections.Generic;
using System.Text;

namespace EmployeeDetailApplication.ViewModels
{
    public class HomeViewModel : BaseViewModel
    {
        public EmployeeOverViewViewModel EmployeeOverViewViewModel { get; set; }
        public HomeViewModel(EmployeeOverViewViewModel employeeOverViewViewModel)
        {
            EmployeeOverViewViewModel = employeeOverViewViewModel;
        }
    }
}
