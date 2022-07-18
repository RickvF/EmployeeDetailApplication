using EmployeeDetailApplication.Models;
using EmployeeDetailApplication.Models.Dto;
using EmployeeDetailApplication.Models.Navigators;
using EmployeeDetailApplication.Services;
using System;
using System.Collections.Generic;
using System.Text;

namespace EmployeeDetailApplication.Commands
{
    //Command to create Employee. Command independant of create implementation (REST, SQL, Mongo). Redirect after creation (location unknown for command)
    public class CreateEmployeeCommand : IEmployeeCommand
    {
        public IEmployeeDataService EmployeeDataService { get; set; }
        public readonly IRenavigator _renavigator;

        public event EventHandler CanExecuteChanged;

        public CreateEmployeeCommand(IEmployeeDataService employeeDataService, IRenavigator renavigator)
        {
            EmployeeDataService = employeeDataService;
            _renavigator = renavigator;
        }

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            if (parameter is Employee)
            {
                Employee employee = (Employee)parameter;
                EmployeeDto employeeDto = new EmployeeDto(employee.name, employee.email, employee.gender, employee.status);
                EmployeeDataService.Create(employeeDto).ContinueWith(res => _renavigator.Renavigate());
            }
        }
    }
}
