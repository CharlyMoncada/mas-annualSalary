using EmployeeAnnualSalary.Api.Domain.Enums;

namespace EmployeeAnnualSalary.Api.Business
{
    public class HourlyContract : IContract
    {
        public ContractTypes ContractType => ContractTypes.Hourly;

        public long CalculateAnnualSalary(long mount)
        {
            return 120 * mount * 12;
        }
    }
}
