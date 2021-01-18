using AutoMapper;
using EmployeeAnnualSalary.Api.Business;
using EmployeeAnnualSalary.Api.DataAccess.Repositories;
using EmployeeAnnualSalary.Api.Domain.Models;
using EmployeeAnnualSalary.Api.Maps;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace EmployeeAnnualSalary.Api.Tests.Business
{
    public class DataServiceTest
    {
        private static IMapper mapper;
        private readonly IDataService service;
        private readonly Mock<IDataRepository> mockRepository;
        private readonly Mock<IContract> mockContract;

        public DataServiceTest()
        {
            mockRepository = new Mock<IDataRepository>();
            mockContract = new Mock<IContract>();
            SetupMapper();

            service = new DataService(
              mockRepository.Object,
              mapper,
              mockContract.Object);
        }

        [Fact]
        public async void GetAllEmployees_WithOneHourlyEmployee_ShouldReturnSuccess()
        {
            var mockEmployee = GetMockOneEmployee("Hourly");

            mockRepository
                .Setup(x => x.GetAllEmployees())
                .ReturnsAsync(mockEmployee);

            var response = await service.GetAllEmployees();

            Assert.True(response.Success);
            Assert.Equal(response.Data.FirstOrDefault().AnnualSalary, 120 * mockEmployee.FirstOrDefault().SalaryPerContract * 12);
        }

        [Fact]
        public async void GetEmployeesById_WithOneMonthlyEmployee_ShouldReturnSuccess()
        {
            var mockEmployee = GetMockOneEmployee("Monthly").FirstOrDefault();

            mockRepository
                .Setup(x => x.GetEmployeeById(It.IsAny<int>()))
                .ReturnsAsync(mockEmployee);

            var response = await service.GetEmployeesById(1);

            Assert.True(response.Success);
            Assert.Equal(response.Data.FirstOrDefault().AnnualSalary, mockEmployee.SalaryPerContract * 12);
        }

        [Fact]
        public async void GetEmployeesById_WithRepositoryException_ShouldReturnNotSuccess()
        {
            var mockEmployee = GetMockOneEmployee("Monthly").FirstOrDefault();

            mockRepository
                .Setup(x => x.GetEmployeeById(It.IsAny<int>()))
                .Throws<Exception>();

            var response = await service.GetEmployeesById(1);

            Assert.False(response.Success);
            Assert.True(!string.IsNullOrEmpty(response.Message));
        }

        private List<Employee> GetMockOneEmployee(string contractType)
        {
            return new List<Employee>()
            {
                new Employee()
                {
                    Id = 1,
                    SalaryPerContract = 200,
                    Contract = new Contract()
                    {
                        Id = 1,
                        ContractType = contractType
                    },
                    Person = new Person()
                    {
                        Id = 1,
                        FirstName = "Carlos",
                        LastName = "Moncada",
                        Identifier = "12594CM"
                    }
                }
            };
        }

        private void SetupMapper()
        {
            if (mapper == null)
            {
                var mappingConfig = new MapperConfiguration(mc =>
                {
                    mc.AddProfile(new EmployeeProfile());
                });

                mapper = mappingConfig.CreateMapper(); ;
            }
        }
    }
}
