using EmployeeDetailApplication.Models;
using EmployeeDetailApplication.Models.Dto;
using EmployeeDetailApplication.Models.Navigators;
using EmployeeDetailApplication.Services;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;

namespace EmployeeDetailApplication.Commands
{
    //Command to open edit page after clicking an Employee
    //Storing the selected employee so edit page can obtain this selected employee
    public class SelectEmployeeCommand : ICommand
    {
        public event EventHandler CanExecuteChanged;

        private readonly IRenavigator _renavigator;
        private readonly SelectedEmployeeStorageService _selectedEmployeeStorageService;

        public SelectEmployeeCommand(IRenavigator renavigator, SelectedEmployeeStorageService selectedEmployeeStorageService)
        {
            _renavigator = renavigator;
            _selectedEmployeeStorageService = selectedEmployeeStorageService;
        }

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            if (parameter is Employee)
            {
                _selectedEmployeeStorageService.selectedEmployee = (Employee)parameter;
                _renavigator.Renavigate();
            }
        }
    }
}
