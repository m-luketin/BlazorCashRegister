using BlazorCashRegister.Data.Entities.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BlazorCashRegister.Domain.Repositories.Interfaces
{
    public interface IEmployeeRepository
    {
        Task<List<Employee>> GetAllEmployees();

        Task<Employee> GetEmployeeById(int id);

        Task<Employee> GetEmployeeByUsername(string username);
    }
}
