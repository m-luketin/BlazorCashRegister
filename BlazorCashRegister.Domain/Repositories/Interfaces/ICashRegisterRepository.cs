using BlazorCashRegister.Data.Entities.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BlazorCashRegister.Domain.Repositories.Interfaces
{
    public interface ICashRegisterRepository
    {
        Task<List<CashRegister>> GetAllCashRegisters();

        Task<bool> DoesExist(int id);
    }
}
