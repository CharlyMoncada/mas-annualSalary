using EmployeeAnnualSalary.Api.DataAccess.Contexts;
using EmployeeAnnualSalary.Api.Domain.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeAnnualSalary.Api.DataAccess.Repositories
{
    public class DataRepository : IDataRepository
    {
        private readonly DataContext _context;

        public DataRepository(DataContext context)
        {
            _context = context;
        }

        public async Task<List<Employee>> GetAllEmployees()
        {
            var employees = await (from employee in _context.Employees
                         join person in _context.Persons
                         on employee.Person.Id equals person.Id
                         join contract in _context.Contracts
                         on employee.Contract.Id equals contract.Id
                         select (new Employee()
                         {
                             Id = employee.Id,
                             Contract = contract,
                             Person = person,
                             SalaryPerContract = employee.SalaryPerContract
                         }
                         )).ToListAsync();

            return employees;
        }

        public async Task<Employee> GetEmployeeById(int id)
        {
            var dbResult = await (from employee in _context.Employees
                             join person in _context.Persons
                             on employee.Person.Id equals person.Id
                             join contract in _context.Contracts
                             on employee.Contract.Id equals contract.Id
                             where employee.Id == id
                             select (new Employee()
                             {
                                 Id = employee.Id,
                                 Contract = contract,
                                 Person = person,
                                 SalaryPerContract = employee.SalaryPerContract
                             }
                             )).ToListAsync();

            return dbResult.FirstOrDefault();
        }

        public async Task<List<Employee>> InsertMockData()
        {
            var employees = GetMockEmployees();

            await _context.Employees.AddRangeAsync(employees);

            await _context.SaveChangesAsync();

            return employees;
        }

        private static List<Employee> GetMockEmployees()
        {
            return new List<Employee>()
            {
                new Employee()
                {
                    SalaryPerContract = 20,
                    Contract = new Contract()
                    {
                        ContractType = "Hourly",
                    },
                    Person = new Person()
                    {
                        FirstName = "Carlos",
                        LastName = "Moncada",
                        Identifier = "123456"
                    }
                },
                new Employee()
                {
                    SalaryPerContract = 3000,
                    Contract = new Contract()
                    {
                        ContractType = "Monthly",
                    },
                    Person = new Person()
                    {
                        FirstName = "Jose",
                        LastName = "Delgado",
                        Identifier = "987654"
                    }
                }
            };
        }
    }
}
