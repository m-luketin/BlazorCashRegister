using System;
using System.Collections.Generic;
using System.Text;

namespace BlazorCashRegister.Data.Entities.Models
{
    public class CashRegister
    {
        public int CashRegisterId { get; set; }
        public ICollection<Receipt> Receipts { get; set; }
    }
}
