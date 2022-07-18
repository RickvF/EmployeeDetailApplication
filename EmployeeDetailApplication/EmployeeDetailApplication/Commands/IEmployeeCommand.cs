using EmployeeDetailApplication.Services;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;

namespace EmployeeDetailApplication.Commands
{
    //Interface for an employee command. Create and Edit using the same control which triggers a command.
    //Interface used so command can be passed to this control, without need to know if command is create or update
    public interface IEmployeeCommand : ICommand
    {
        IEmployeeDataService EmployeeDataService { get; set; }
    }
}
