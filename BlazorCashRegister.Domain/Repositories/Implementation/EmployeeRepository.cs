using BlazorCashRegister.Data.Entities;
using BlazorCashRegister.Data.Entities.Models;
using BlazorCashRegister.Domain.Repositories.Interfaces;
using System.Collections.Generic;
using BlazorCashRegister.Domain.Helpers;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System.IO;

namespace BlazorCashRegister.Domain.Repositories.Implementation
{
    
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly CashRegisterContext _context;
        public EmployeeRepository(CashRegisterContext context)
        {
            _context = context;
        }

        public async Task<List<Employee>> GetAllEmployees()
        {
            return await _context.Employees.ToListAsync();
        }

        public async Task<Employee> GetEmployeeById(int id)
        {
            return await _context.Employees.FindAsync(id);
        }

        public async Task<Employee> GetEmployeeByUsername(string username)
        {
            return await _context.Employees.FirstOrDefaultAsync(e => e.Name == username);
        }

        public async Task<string> ValidateEmployee(string username, string password)
        {
            var employeeToValidate = await _context.Employees.FirstOrDefaultAsync(e => e.Name == username);
            if (employeeToValidate is null || !string.Equals(employeeToValidate.Password, password))
                return string.Empty;

            var configurationBuilder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("../BlazorCashRegister/appsettings.json", optional: true);

            var configuration = configurationBuilder.Build();
            var jwtHelper = new JwtHelper(configuration);
            var token = jwtHelper.GetJwtToken(employeeToValidate);

            return token;
        }
    }
}
