namespace EmployeeAnnualSalary.Api.Domain.Models
{
    public class Employee
    {
        public int Id { get; set; }

        public Person Person { get; set; }

        public Contract Contract { get; set; }

        public long SalaryPerContract { get; set; }
    }
}
