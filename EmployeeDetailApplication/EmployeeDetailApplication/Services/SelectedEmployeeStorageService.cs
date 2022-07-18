using EmployeeDetailApplication.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace EmployeeDetailApplication.Services
{
    //Storage of selected employee between EditViewModel and OverViewViewModel
    public class SelectedEmployeeStorageService
    {
        public Employee selectedEmployee { get; set; }
    }
}
