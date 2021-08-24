using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Text;

namespace BlazorCashRegister.Data.Entities.Models
{
    public class Employee
    {
        public int EmployeeId { get; set; }
        public string Name { get; set; }
        public ICollection<Receipt> Receipts { get; set; }
        public string Password { get; set; }
        public string Token { get; set; }
    }
}
