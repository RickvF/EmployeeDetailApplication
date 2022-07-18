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
    //Command to update an Employee. Command independant of update implementation (REST, SQL, Mongo). Redirect after updating (location unknown for command)
    public class EditEmployeeCommand : IEmployeeCommand
    {
        public IEmployeeDataService EmployeeDataService { get; set; }
        private readonly IRenavigator _renavigator;

        public event EventHandler CanExecuteChanged;        

        public EditEmployeeCommand(IEmployeeDataService employeeDataService, IRenavigator renavigator)
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
            if(parameter is Employee)
            {
                Employee employee = (Employee)parameter;
                EmployeeDto employeeDto = new EmployeeDto(employee.name, employee.email, employee.gender, employee.status);
                EmployeeDataService.Update(employee.id, employeeDto).ContinueWith(res => _renavigator.Renavigate());
            }
        }
    }
}
