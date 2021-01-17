using EmployeeAnnualSalary.Api.Domain.Enums;
using System;

namespace EmployeeAnnualSalary.Api.Business
{
    public class ContractFactory
    {
        public IContract Create(ContractTypes contractType)
        {
            switch (contractType)
            {
                case ContractTypes.Hourly:
                    return new HourlyContract();
                case ContractTypes.Monthly:
                    return new MonthlyContract();
                default:
                    throw new NotImplementedException();
            }
        }
    }
}
