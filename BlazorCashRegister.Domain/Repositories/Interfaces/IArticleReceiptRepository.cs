using BlazorCashRegister.Data.Entities.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BlazorCashRegister.Domain.Repositories.Interfaces
{
    public interface IArticleReceiptRepository
    {
        Task<List<ArticleReceipt>> GetAllArticleReceipts();

        Task<bool> AddArticleReceipt(int receiptId, int articleId, int quantity);

        Task<List<Tuple<int, int>>> GetArticlesWithQuantityByReceiptId(int id);
    }
}
