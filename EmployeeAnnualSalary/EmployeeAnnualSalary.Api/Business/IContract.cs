using EmployeeAnnualSalary.Api.Domain.Enums;

namespace EmployeeAnnualSalary.Api.Business
{
    public interface IContract
    {
        ContractTypes ContractType { get; }

        long CalculateAnnualSalary(long mount);
    }
}
