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
    public class EditEViewModel : BaseViewModel
    {
        private SelectedEmployeeStorageService _selectedEmployeeStorageService;

        public IEmployeeCommand EmployeeCommand { get; }
        
        public Employee Employee { get; set; }

        public string buttonName { get; } = "Edit";

        public EditEViewModel(IEmployeeDataService employeeDataService, SelectedEmployeeStorageService selectedEmployeeStorageService, IRenavigator renavigator)
        {
            EmployeeCommand = new EditEmployeeCommand(employeeDataService, renavigator);
            _selectedEmployeeStorageService = selectedEmployeeStorageService;
            //Obtain selected employee in the EmployeeOverViewViewModel
            Employee = _selectedEmployeeStorageService.selectedEmployee;
        }
    }
}
