using EmployeeAnnualSalary.Api.Domain.Enums;

namespace EmployeeAnnualSalary.Api.Domain.DTOs
{
    public class EmployeeDTO
    {
        public int Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public ContractTypes ContractType { get; set; }

        public long AnnualSalary { get; set; }
    }
}
