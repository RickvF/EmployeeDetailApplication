using EmployeeDetailApplication.Models;
using EmployeeDetailApplication.Services;
using System;
using System.Collections.Generic;
using System.Text;

namespace EmployeeDetailApplication.ViewModels
{
    public class EmployeeOverViewViewModel : BaseViewModel
    {
        private readonly IEmployeeDataService _employeeDataService;

        private List<Employee> _employees;
        public List<Employee> Employees
        {
            get
            {
                return _employees;
            }
            set
            {
                _employees = value;
                OnPropertyChanged(nameof(Employees));
            }
        }

        public EmployeeOverViewViewModel(IEmployeeDataService employeeDataService)
        {
            _employeeDataService = employeeDataService;
        }

        public static EmployeeOverViewViewModel LoadEmployeeOverViewViewModel(IEmployeeDataService employeeDataService)
        {
            EmployeeOverViewViewModel employeeOverViewViewModel = new EmployeeOverViewViewModel(employeeDataService);
            employeeOverViewViewModel.ObtainEmployees();
            return employeeOverViewViewModel;
        }

        public void ObtainEmployees()
        {
            _employeeDataService.getAllEmployees().ContinueWith(task =>
            {
                if(task.Exception == null)
                {
                    Employees = task.Result;
                }
            });
        }

        public void SearchByName(string name)
        {
            _employeeDataService.searchByName(name).ContinueWith(task =>
            {
                if(task.Exception == null)
                {
                    Employees = task.Result;
                }
            });
        }

        public void DeleteEmployee(int id)
        {
            _employeeDataService.Delete(id).ContinueWith(task =>
            {
                if(task.Exception == null)
                {
                    this.ObtainEmployees();    
                }
            });
        }

    }
}
