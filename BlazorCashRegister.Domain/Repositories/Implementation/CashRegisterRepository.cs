using BlazorCashRegister.Data.Entities;
using BlazorCashRegister.Data.Entities.Models;
using BlazorCashRegister.Domain.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorCashRegister.Domain.Repositories.Implementation
{
    public class CashRegisterRepository : ICashRegisterRepository
    {
        private readonly CashRegisterContext _context;
        public CashRegisterRepository(CashRegisterContext context)
        {
            _context = context;
        }
        
        public async Task<List<CashRegister>> GetAllCashRegisters()
        {
            return await _context.CashRegisters.ToListAsync();
        }
        
        public async Task<bool> DoesExist(int id)
        {
            var cashRegisterToFind = await _context.CashRegisters.FindAsync(id);

            return cashRegisterToFind is not null;
        }
    }
}
