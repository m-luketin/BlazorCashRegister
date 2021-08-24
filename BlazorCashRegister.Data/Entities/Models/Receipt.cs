using System;
using System.Collections.Generic;
using System.Text;

namespace BlazorCashRegister.Data.Entities.Models
{
    public class Receipt
    {
        public int ReceiptId { get; set; }
        public Guid SerialNumber { get; set; }
        public ICollection<ArticleReceipt> ArticleReceipts { get; set; }
        public Employee Employee { get; set; }
        public CashRegister Register { get; set; }
        public DateTime TimeStamp { get; set; }
    }
}
