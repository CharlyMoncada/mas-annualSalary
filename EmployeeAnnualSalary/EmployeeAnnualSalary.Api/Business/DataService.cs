using AutoMapper;
using EmployeeAnnualSalary.Api.DataAccess.Repositories;
using EmployeeAnnualSalary.Api.Domain;
using EmployeeAnnualSalary.Api.Domain.DTOs;
using EmployeeAnnualSalary.Api.Domain.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EmployeeAnnualSalary.Api.Business
{
    public class DataService : IDataService
    {
        private readonly IDataRepository _repository;
        private readonly IMapper _mapper;
        private readonly IContract _contract;

        public DataService(
            IDataRepository repository,
            IMapper mapper,
            IContract contract)
        {
            _repository = repository;
            _mapper = mapper;
            _contract = contract;
        }

        public async Task<ServiceResponse<List<EmployeeDTO>>> GetAllEmployees()
        {
            var serviceResponse = new ServiceResponse<List<EmployeeDTO>>();

            try
            {
                var dbEmployees = await _repository.GetAllEmployees();

                var data = new List<EmployeeDTO>();
                dbEmployees.ForEach(dbEmployee =>
                {
                    var employeeDTO = _mapper.Map<EmployeeDTO>(dbEmployee);
                    data.Add(employeeDTO);
                });

                serviceResponse.Data = data;
            }
            catch (System.Exception ex)
            {
                serviceResponse.Success = false;
                serviceResponse.Message = ex.Message;
            }

            return serviceResponse;
        }

        public async Task<ServiceResponse<List<EmployeeDTO>>> GetEmployeesById(int id)
        {
            var serviceResponse = new ServiceResponse<List<EmployeeDTO>>();

            try
            {
                var dbEmployee = await _repository.GetEmployeeById(id);
                var employeeDTO = _mapper.Map<EmployeeDTO>(dbEmployee);

                serviceResponse.Data = 
                    employeeDTO != null ? 
                    new List<EmployeeDTO> { employeeDTO } :
                    new List<EmployeeDTO>();
            }
            catch (System.Exception ex)
            {
                serviceResponse.Success = false;
                serviceResponse.Message = ex.Message;
            }

            return serviceResponse;
        }

        public async Task<ServiceResponse<List<Employee>>> InsertMockData()
        {
            try
            {
                var dbEmployess = await _repository.InsertMockData();

                return new ServiceResponse<List<Employee>>()
                {
                    Data = dbEmployess
                };

            }
            catch (System.Exception ex)
            {
                return new ServiceResponse<List<Employee>>()
                {
                    Success = false,
                    Message = ex.Message
                };
            }
        }
    }
}
