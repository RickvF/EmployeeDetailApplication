using EmployeeDetailApplication.Services;
using System;
using System.Collections.Generic;
using System.Text;

namespace EmployeeDetailApplication.ViewModels.Factories
{
    public class EmployeeOverviewViewModelFactory : IViewModelFactory<EmployeeOverViewViewModel>
    {
        private readonly IEmployeeDataService _employeeDataService;

        public EmployeeOverviewViewModelFactory(IEmployeeDataService employeeDataService)
        {
            _employeeDataService = employeeDataService;
        }
        public EmployeeOverViewViewModel CreateViewModel()
        {
            return EmployeeOverViewViewModel.LoadEmployeeOverViewViewModel(_employeeDataService);
        }
    }
}
