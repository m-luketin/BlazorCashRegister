using System;
using System.Collections.Generic;
using System.Text;

namespace BlazorCashRegister.Data.Entities.Models
{
    public class ArticleReceipt
    {
        public int ArticleId { get; set; }
        public Article Article { get; set; }
        public int ReceiptId { get; set; }
        public Receipt Receipt { get; set; }
        public int Quantity { get; set; }
    }
}
