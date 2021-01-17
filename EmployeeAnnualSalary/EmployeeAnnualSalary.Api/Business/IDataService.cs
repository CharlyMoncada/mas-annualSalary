using EmployeeAnnualSalary.Api.Domain;
using EmployeeAnnualSalary.Api.Domain.DTOs;
using EmployeeAnnualSalary.Api.Domain.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EmployeeAnnualSalary.Api.Business
{
    public interface IDataService
    {
        Task<ServiceResponse<List<Employee>>> InsertMockData();

        Task<ServiceResponse<List<EmployeeDTO>>> GetAllEmployees();

        Task<ServiceResponse<List<EmployeeDTO>>> GetEmployeesById(int id);
    }
}
