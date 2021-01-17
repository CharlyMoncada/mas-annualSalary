using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EmployeeAnnualSalary.Api.Domain.Enums;

namespace EmployeeAnnualSalary.Api.Business
{
    public class MonthlyContract : IContract
    {
        public ContractTypes ContractType => ContractTypes.Monthly;

        public long CalculateAnnualSalary(long mount)
        {
            return mount * 12;
        }
    }
}
