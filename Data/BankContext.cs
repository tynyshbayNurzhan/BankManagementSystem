using BankManagementSystem.Models;
using Microsoft.EntityFrameworkCore.SqlServer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace BankManagementSystem.Data
{
    public class BankContext : IdentityDbContext<Users>
    {
        public BankContext(DbContextOptions options) : base(options)
        {
        }

        public new DbSet<Users> Users { get; set; }
        public DbSet<Accounts> Accounts { get; set; }
        public DbSet<BankTotalBalance> BankTotalBalances { get; set; }
        public DbSet<Currencies> Currencies { get; set; }
        public DbSet<Operations> Operations { get; set; }
        public DbSet<TransactionHistories> TransactionHistories { get; set; }
        public DbSet<CurrencyExchange> GetCurrencyExchanges { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<Accounts>()
                .HasOne(a => a.currency)
                .WithMany(c => c.accounts);

            builder.Entity<BankTotalBalance>()
            .HasOne(p => p.currency)
            .WithOne(i => i.bankTotalBalance)
            .HasForeignKey<Currencies>(b => b.bank_total_balance_id);

            builder.Entity<CurrencyExchange>()
            .HasOne(p => p.currency)
            .WithOne(i => i.currencyExchange)
            .HasForeignKey<Currencies>(b => b.currency_exchange_id);

            //builder.Entity<TransactionHistories>()
            //    .HasOne(e => e.manager)
            //    .WithMany(c => c.transactionHistories);

            builder.Entity<TransactionHistories>()
                .HasOne(e => e.senderAccount)
                .WithMany(c => c.transactionHistories);

            builder.Entity<TransactionHistories>()
                .HasOne(e => e.receiverAccount)
                .WithMany(c => c.transaction_histories2);

            builder.Entity<TransactionHistories>()
                .HasOne(e => e.operation)
                .WithMany(c => c.transactionHistories);

            builder.Entity<TransactionHistories>()
                .HasOne(e => e.currency)
                .WithMany(c => c.TransactionHistories);
        }
    }
    
}
