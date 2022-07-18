using EmployeeDetailApplication.Commands;
using EmployeeDetailApplication.Models;
using EmployeeDetailApplication.Models.Navigators;
using EmployeeDetailApplication.Services;
using System;
using System.Collections.Generic;
using System.Text;

namespace EmployeeDetailApplication.ViewModels
{
    public class CreateEViewModel : BaseViewModel
    {
        public  IEmployeeCommand EmployeeCommand { get; }

        public Employee Employee { get; set; }

        public string buttonName { get; } = "Create";

        public CreateEViewModel(IEmployeeDataService employeeDataService, IRenavigator renavigator)
        {
            EmployeeCommand = new CreateEmployeeCommand(employeeDataService, renavigator);
            Employee = new Employee();
            Employee.name = "Name";
            Employee.email = "Email";
            Employee.gender = "Gender";
            Employee.status = "Status";
        }
    }
}
