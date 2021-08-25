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
    public class ArticleRepository : IArticleRepository
    {
        private readonly CashRegisterContext _context;
        public ArticleRepository(CashRegisterContext context)
        {
            _context = context;
        }

        public async Task<List<Article>> GetAllArticles()
        {
            return await _context.Articles.ToListAsync();
        }

        public async Task<bool> AddArticle(Article articleToAdd)
        {
            if(!IsNameValid(articleToAdd))
                return false;

            await _context.Articles.AddAsync(articleToAdd);
            await _context.SaveChangesAsync();

            return true;
        }

        public async Task<bool> EditArticle(Article editedArticle)
        {
            if(!IsNameValid(editedArticle))
                return false;

            var articleToEdit = await _context.Articles.FirstOrDefaultAsync(a => a.Barcode == editedArticle.Barcode);
            if(articleToEdit is null)
                return false;

            articleToEdit.Price = editedArticle.Price;
            articleToEdit.Name = editedArticle.Name;
            articleToEdit.UnitsInStock = editedArticle.UnitsInStock;
            await _context.SaveChangesAsync();

            return true;
        }

        public async Task<Article> GetArticleById(int id)
        {
            return await _context.Articles.FindAsync(id);
        }

        public async Task<Article> GetArticleByName(string name)
        {
            return await _context.Articles.FirstOrDefaultAsync( a => string.Equals(a.Name, name, StringComparison.CurrentCultureIgnoreCase));
        }

        public async Task<List<Article>> SearchArticles(string name)
        {
            return await _context.Articles.Where(a => a.Name.Contains(name)).ToListAsync();
        }

        public async Task<bool> UpdateQuantity(string name, int quantityAdded)
        {
            if(quantityAdded < 1)
                return false;

            var articleToUpdate = await _context.Articles.FirstOrDefaultAsync(a => string.Equals(a.Name, name, StringComparison.CurrentCultureIgnoreCase));
            if(articleToUpdate is null)
                return false;

            articleToUpdate.UnitsInStock += quantityAdded;
            await _context.SaveChangesAsync();

            return true;
        }

        public async Task<bool> RemoveArticle(Article articleToRemove)
        {
            var articleEntity = await _context.Articles.FirstOrDefaultAsync(a => a.Barcode == articleToRemove.Barcode);
            if (articleEntity is null)
                return false;

            _context.Articles.Remove(articleEntity);
            await _context.SaveChangesAsync();

            return true;
        }

        private bool IsNameValid(Article article)
        {
            return article.Name.Length > 3;
        }
    }
}
