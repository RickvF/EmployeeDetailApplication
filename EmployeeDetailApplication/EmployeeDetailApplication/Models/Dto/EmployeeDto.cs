using System;
using System.Collections.Generic;
using System.Text;

namespace EmployeeDetailApplication.Models.Dto
{
    //Class with generic properties for View, Create, Update of Employee
    public class EmployeeDto
    {
        public string name { get; set; }
        public string email { get; set; }
        public string gender { get; set; }
        public string status { get; set; }

        public EmployeeDto() { }
        public EmployeeDto(string name, string email, string gender, string status) 
        {
            this.name = name;
            this.email = email;
            this.gender = gender;
            this.status = status;
        }
    }
}
