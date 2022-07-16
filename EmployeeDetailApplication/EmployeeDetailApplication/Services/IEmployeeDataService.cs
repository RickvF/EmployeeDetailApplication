using EmployeeDetailApplication.Models;
using EmployeeDetailApplication.Models.Dto;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeDetailApplication.Services
{
    public interface IEmployeeDataService : IDataService<EmployeeDto>
    {
        Task<List<Employee>> getAllEmployees();

        Task<List<Employee>> searchByName(string name);

    }
}
