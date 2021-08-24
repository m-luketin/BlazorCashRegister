using BlazorCashRegister.Data.Entities.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BlazorCashRegister.Domain.Repositories.Interfaces
{
    public interface IArticleRepository
    {
        Task<List<Article>> GetAllArticles();

        Task<bool> AddArticle(Article articleToAdd);

        Task<bool> EditArticle(Article editedArticle);

        Task<Article> GetArticleById(int id);

        Task<Article> GetArticleByName(string name);

        Task<List<Article>> SearchArticles(string name);

        Task<bool> UpdateQuantity(string name, int quantityAdded);

    }
}
