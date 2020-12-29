using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using Routine.API.DtoParameters;
using Routine.API.Entities;
using Routine.API.Helpers;

namespace Routine.API.Services
{
    public interface ICompanyRepository
    {
         Task<PagedList<Company>> GetCompaniesAsync(CompanyDtoParameters parameters);
        Task<Company> GetCompanyAsync(Guid companyId);
        Task<IEnumerable<Company>> GetCompaniesAsync(IEnumerable<Guid> companyIds);

        void AddCompany(Company company);
        void UpdateCompany(Company company);
        void DeleteCompany(Company company);
        Task<bool> CompanyExistsAsync(Guid companyId);

       // Task<IEnumerable<Employee>> GetEmployeesAsync(Guid companyId,string genderDisplay,string q);
        Task<IEnumerable<Employee>> GetEmployeesAsync(Guid companyId, EmployeeDtoParameters parameters);

        Task<Employee> GetEmployeeAsync(Guid companyId, Guid employeeId);
        void AddEmployee(Guid companyId, Employee employee);
        void UpdateEmployee(Employee employee);
        void DeleteEmployee(Employee employee);

        Task<bool> SaveAsync();

    }
}