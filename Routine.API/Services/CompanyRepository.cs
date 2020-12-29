using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Routine.API.Date;
using Routine.API.DtoParameters;
using Routine.API.Entities;
using Routine.API.Helpers;
using Routine.API.Models;

namespace Routine.API.Services
{
    public class CompanyRepository : ICompanyRepository
    {
        private readonly RoutineDbContext _context;
        private readonly IPropertyMappingService _propertyMappingService;

        public CompanyRepository(RoutineDbContext context,IPropertyMappingService propertyMappingService)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
            _propertyMappingService = propertyMappingService ?? throw new ArgumentNullException(nameof(propertyMappingService));
        }

        public async Task<PagedList<Company>> GetCompaniesAsync(CompanyDtoParameters parameters)
        {
            if (parameters == null) throw new ArgumentNullException(nameof(parameters));
            //if (string.IsNullOrWhiteSpace(parameters.CompanyName) && string.IsNullOrWhiteSpace(parameters.SearchTerm))
            //{
            //    return await _context.Companies.ToListAsync();
            //}

            var queryExpression = _context.Companies as IQueryable<Company>;

            if (!string.IsNullOrWhiteSpace(parameters.CompanyName))
            {
                var cmpName = parameters.CompanyName.Trim();
                queryExpression = queryExpression.Where(x => x.Name == cmpName);
            }

            if (!string.IsNullOrWhiteSpace(parameters.SearchTerm))
            {
                var search = parameters.SearchTerm.Trim();
                queryExpression = queryExpression.Where(x => x.Name.Contains(search) ||
                                                             x.Introduction.Contains(search));
            }

            var mappingDictionary = _propertyMappingService.GetPropertyMapping<CompanyDto, Company>();

            queryExpression = queryExpression.ApplySort(parameters.OrderBy, mappingDictionary);

            //queryExpression = queryExpression.Skip(parameters.PageSize * (parameters.PageNumber - 1))
            //    .Take(parameters.PageSize);

           // return await queryExpression.ToListAsync();

           return await PagedList<Company>.CreateAsync(queryExpression, parameters.PageNumber, parameters.PageSize);
        }

        public async Task<Company> GetCompanyAsync(Guid companyId)
        {
            if (companyId == Guid.Empty)
            {
                throw new ArgumentNullException(nameof(companyId));
            }

            return await _context.Companies.FirstOrDefaultAsync(x => x.Id == companyId);
        }


        public async Task<IEnumerable<Company>> GetCompaniesAsync(IEnumerable<Guid> companyIds)
        {
            if (companyIds == null)
            {
                throw new ArgumentNullException(nameof(companyIds));
            }

            return await _context.Companies.Where(x => companyIds.Contains(x.Id)).OrderBy(x => x.Name).ToListAsync();
        }

        public void AddCompany(Company company)
        {
            if (company == null)
            {
                throw new ArgumentNullException(nameof(company));
            }

            company.Id = Guid.NewGuid();
            if (company.Employees!=null)
            {
                foreach (var employee in company.Employees)
                {
                    employee.Id = Guid.NewGuid();
                }

            }
         

            _context.Companies.Add(company);
        }

        public void UpdateCompany(Company company)
        {
            //_context.Entry(company).State = EntityState.Modified;
        }

        public void DeleteCompany(Company company)
        {
            if (company == null)
            {
                throw new ArgumentNullException(nameof(company));
            }

            _context.Companies.Remove(company);
        }

        public async Task<bool> CompanyExistsAsync(Guid companyId)
        {
            if (companyId == Guid.Empty)
            {
                throw new ArgumentNullException(nameof(companyId));
            }

            return await _context.Companies.AnyAsync(x => x.Id == companyId);
        }

        public  async Task<IEnumerable<Employee>> GetEmployeesAsync(Guid companyId, EmployeeDtoParameters parameters)
        {
            if (companyId == Guid.Empty)
            {
                throw new ArgumentNullException(nameof(companyId));
            }

            var genderDisplay = parameters.Gender;
            var q = parameters.Q;
            //if (string.IsNullOrWhiteSpace(genderDisplay) && string.IsNullOrWhiteSpace(q))
            //{
            //    return await _context.Employees.Where(x => x.CompanyId == companyId).OrderBy(x => x.EmployeeNo).ToListAsync();
            //}

            var items = _context.Employees.Where(x => x.CompanyId == companyId);

            if (!string.IsNullOrWhiteSpace(genderDisplay))
            {
                genderDisplay = genderDisplay.Trim();
                var gender = Enum.Parse<Gender>(genderDisplay);

                items = items.Where(x => x.Gender == gender);
            }

            if (!string.IsNullOrWhiteSpace(q))
            {
                q = q.Trim();
                items = items.Where(x => x.EmployeeNo.Contains(q) ||
                                         x.FirstName.Contains(q) ||
                                         x.LastName.Contains(q));
            }

            //if (!string.IsNullOrWhiteSpace(parameters.OrderBy))
            //{
            //    if (parameters.OrderBy.ToLowerInvariant()=="name")
            //    {
            //        items = items.OrderBy(x => x.FirstName).ThenBy(x => x.FirstName);
            //    }
            //}
            var mappingDictionary = _propertyMappingService.GetPropertyMapping<EmployeeDto, Employee>();

            var item = items.ApplySort(parameters.OrderBy, mappingDictionary);


         return await items.ToListAsync();
        }

        public async Task<IEnumerable<Employee>> GetEmployeesAsync(Guid companyId, string genderDisplay, string q)
        {
            if (companyId == Guid.Empty)
            {
                throw new ArgumentNullException(nameof(companyId));
            }

            if (string.IsNullOrWhiteSpace(genderDisplay) && string.IsNullOrWhiteSpace(q))
            {
                return await _context.Employees.Where(x => x.CompanyId == companyId)
                    .OrderBy(x => x.EmployeeNo).ToListAsync();
            }

            var items = _context.Employees.Where(x => x.CompanyId == companyId);

            if (!string.IsNullOrWhiteSpace(genderDisplay))
            {
                genderDisplay = genderDisplay.Trim();
                var gender = Enum.Parse<Gender>(genderDisplay);

                items = items.Where(x => x.Gender == gender);
            }

            if (!string.IsNullOrWhiteSpace(q))
            {
                q = q.Trim();
                items = items.Where(x => x.EmployeeNo.Contains(q) ||
                                         x.FirstName.Contains(q) ||
                                         x.LastName.Contains(q));
            }

            return await items.OrderBy(x => x.EmployeeNo).ToListAsync();
        }

        public async Task<Employee> GetEmployeeAsync(Guid companyId, Guid employeeId)
        {
            if (companyId == Guid.Empty)
            {
                throw new ArgumentNullException(nameof(companyId));
            }

            if (employeeId == Guid.Empty)
            {
                throw new ArgumentNullException(nameof(employeeId));
            }

            return await _context.Employees.Where(x => x.CompanyId == companyId && x.Id == employeeId)
                .FirstOrDefaultAsync();
        }

        public void AddEmployee(Guid companyId, Employee employee)
        {
            if (employee == null) throw new ArgumentNullException(nameof(employee));
            if (companyId == Guid.Empty)
            {
                throw new ArgumentNullException(nameof(companyId));
            }

            employee.CompanyId = companyId;
            _context.Employees.Add(employee);
        }

        public void UpdateEmployee(Employee employee)
        {
            //
        }

        public void DeleteEmployee(Employee employee) => _context.Employees.Remove(employee);

        public async Task<bool> SaveAsync() => await _context.SaveChangesAsync() >= 0;
    }
}