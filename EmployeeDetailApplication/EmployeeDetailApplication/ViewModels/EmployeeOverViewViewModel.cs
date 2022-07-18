using EmployeeDetailApplication.Commands;
using EmployeeDetailApplication.Models;
using EmployeeDetailApplication.Models.Navigators;
using EmployeeDetailApplication.Services;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;

namespace EmployeeDetailApplication.ViewModels
{
    public class EmployeeOverViewViewModel : BaseViewModel
    {
        private readonly IEmployeeDataService _employeeDataService;
        private readonly IRenavigator _renavigator;
        private readonly SelectedEmployeeStorageService _selectedEmployeeStorageService;
        public ICommand SelectEmployeeCommand { get; set; }

        private List<Employee> _employees;
        //Trigger Recreation of the DataGrid when Employees get a new value due to API calls
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

        public EmployeeOverViewViewModel(IEmployeeDataService employeeDataService, 
            IRenavigator renavigator, 
            SelectedEmployeeStorageService selectedEmployeeStorageService)
        {
            _employeeDataService = employeeDataService;
            _renavigator = renavigator;
            _selectedEmployeeStorageService = selectedEmployeeStorageService;
            SelectEmployeeCommand = new SelectEmployeeCommand(_renavigator, _selectedEmployeeStorageService);
        }

        public static EmployeeOverViewViewModel LoadEmployeeOverViewViewModel(IEmployeeDataService employeeDataService, 
            IRenavigator renavigator,
            SelectedEmployeeStorageService selectedEmployeeStorageService)
        {
            EmployeeOverViewViewModel employeeOverViewViewModel = new EmployeeOverViewViewModel(employeeDataService, renavigator, selectedEmployeeStorageService);
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
