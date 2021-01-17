using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeAnnualSalary.Api.Domain.Models
{
    public class Contract
    {
        public int Id { get; set; }

        public string ContractType { get; set; }

        //public long Mount { get; set; }
    }
}
