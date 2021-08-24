using BlazorCashRegister.Data.Entities;
using BlazorCashRegister.Data.Entities.Models;
using BlazorCashRegister.Domain.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorCashRegister.Domain.Repositories.Implementation
{
    public class ReceiptRepository : IReceiptRepository
    {
        private readonly CashRegisterContext _context;
        public ReceiptRepository(CashRegisterContext context)
        {
            _context = context;
        }

        public async Task<List<Receipt>> GetAllReceipts()
        {
            return await _context.Receipts.Include( r => r.Register ).Include( r => r.Employee ).ToListAsync();
        }

        public async Task<int> AddReceipt(Guid serialNumber, DateTime timeStamp, int employeeId, int cashRegisterId, List<ArticleReceipt> articleReceipts)
        {
            var employee = await _context.Employees.FindAsync(employeeId);
            if(employee is null)
                return 0;

            var cashRegister = _context.CashRegisters.Find(cashRegisterId);
            if(cashRegister is null)
                return 0;

            await _context.Receipts.AddAsync(new Receipt {
                SerialNumber = serialNumber,
                TimeStamp = timeStamp,
                Employee = employee,
                Register = cashRegister,
                ArticleReceipts = articleReceipts,
            });
            await _context.SaveChangesAsync();

            var receipt = await _context.Receipts.FirstOrDefaultAsync(r => Equals(serialNumber, r.SerialNumber));
            if(receipt is null)
                return 0;

            return receipt.ReceiptId;
        }

        public async Task<Receipt> GetReceiptById(int id)
        {
            return await _context.Receipts.FindAsync(id);
        }

        private bool DoesExist(Receipt receipt)
        {
            return _context.Receipts.Any(r => r.SerialNumber == receipt.SerialNumber);
        }
    }
}
