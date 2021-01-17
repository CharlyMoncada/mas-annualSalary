using EmployeeAnnualSalary.Api.Domain.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EmployeeAnnualSalary.Api.DataAccess.Repositories
{
    public interface IDataRepository
    {
        Task<List<Employee>> GetAllEmployees();

        Task<Employee> GetEmployeeById(int id);

        Task<List<Employee>> InsertMockData();
    }
}
