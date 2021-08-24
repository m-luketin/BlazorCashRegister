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
    public class ArticleReceiptRepository : IArticleReceiptRepository
    {
        private readonly CashRegisterContext _context;
        public ArticleReceiptRepository(CashRegisterContext context)
        {
            _context = context;
        }

        public async Task<List<ArticleReceipt>> GetAllArticleReceipts()
        {
            return await _context.ArticleReceipts.ToListAsync();
        }

        public async Task<List<Tuple<int, int>>> GetArticlesWithQuantityByReceiptId(int id)
        {
            var articleReceipts=  await _context.ArticleReceipts.Where(ar => ar.ReceiptId == id).ToListAsync();
            var articlesWithQuantity = new List<Tuple<int, int>>();

            foreach(var articleReceipt in articleReceipts)
                articlesWithQuantity.Add(new Tuple<int, int> ( articleReceipt.ArticleId, articleReceipt.Quantity ));

            return articlesWithQuantity;
        }

        public async Task<bool> AddArticleReceipt(int receiptId, int articleId, int quantity)
        {
            var receipt = await _context.Receipts.FindAsync(receiptId);
            if(receipt is null)
                return false;

            var article = await _context.Articles.FindAsync(articleId);
            if(article is null)
                return false;

            if(article.UnitsInStock < quantity)
                return false;
            
            article.UnitsInStock -= quantity;

            await _context.ArticleReceipts.AddAsync(new ArticleReceipt
            {
                ReceiptId = receiptId,
                ArticleId = articleId,
                Quantity = quantity
            });
            await _context.SaveChangesAsync();
            
            return true;
        }
    }
}
