using EmployeeDetailApplication.Models.Dto;
using System;
using System.Collections.Generic;
using System.Text;

namespace EmployeeDetailApplication.Models
{
    //Class containing additional properties for View of Employees
    public class Employee : EmployeeDto
    {
        public int id { get; set; }      
    }
}
