using BlazorCashRegister.Data.Entities.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BlazorCashRegister.Domain.Repositories.Interfaces
{
    public interface IReceiptRepository
    {
        Task<List<Receipt>> GetAllReceipts();

        Task<int> AddReceipt(Guid serialNumber, DateTime timeStamp, int employeeId, int cashRegisterId, List<ArticleReceipt> articleReceipts);

        Task<Receipt> GetReceiptById(int id);
    }
}
