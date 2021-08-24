using BlazorCashRegister.Data.Entities.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace BlazorCashRegister.Data.Entities
{
    public class CashRegisterContext : DbContext
    {
        public CashRegisterContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Article> Articles { get; set; }
        public DbSet<ArticleReceipt> ArticleReceipts { get; set; }
        public DbSet<CashRegister> CashRegisters { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Receipt> Receipts { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ArticleReceipt>()
                .HasKey(a => new { a.ArticleId, a.ReceiptId });
            modelBuilder.Entity<ArticleReceipt>()
                .HasOne(a => a.Article)
                .WithMany(a => a.ArticleReceipts)
                .HasForeignKey(a => a.ArticleId);
            modelBuilder.Entity<ArticleReceipt>()
                 .HasOne(a => a.Receipt)
                 .WithMany(a => a.ArticleReceipts)
                 .HasForeignKey(a => a.ReceiptId);
        }
    }
}
