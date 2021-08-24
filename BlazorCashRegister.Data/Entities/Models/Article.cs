using System;
using System.Collections.Generic;
using System.Text;

namespace BlazorCashRegister.Data.Entities.Models
{
    public class Article
    {
        public int ArticleId { get; set; }
        public string Name { get; set; }
        public Guid Barcode { get; set; }
        public int UnitsInStock { get; set; }
        public int Price { get; set; }
        public bool IsTaxRateReduced { get; set; }
        public ICollection<ArticleReceipt> ArticleReceipts { get; set; }
    }
}
