using BankManagementSystem.Data;
using BankManagementSystem.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BankManagementSystem.Abstractions
{
    public class TrancastionHistoriesRepo: ITransactionHistoriesRepo
    {
        readonly BankContext _context;
        public TrancastionHistoriesRepo(BankContext context)
        {
            _context = context;
        }

        public void Add(TransactionHistories transaction_histories)
        {
            _context.Add(transaction_histories);
        }

        public void Update(TransactionHistories transaction_histories)
        {
            _context.Update(transaction_histories);
        }

        public void Delete(TransactionHistories transaction_histories)
        {
            _context.Remove(transaction_histories);
        }

        public bool Exist(int id)
        {
            return _context.TransactionHistories.Any(m => m.id == id);
        }

        public Task<List<TransactionHistories>> GetAll()
        {
            return _context.TransactionHistories.ToListAsync();
        }

        public Task<TransactionHistories> GetDetail(int? id)
        {
            return _context.TransactionHistories.FirstOrDefaultAsync(m => m.id == id);
        }

        public Task Save()
        {
            return _context.SaveChangesAsync();
        }

        public DbSet<Currencies> GetCurrencies()
        {
            return _context.Currencies;
        }

        public DbSet<Operations> GetOperations()
        {
            return _context.Operations;
        }

        public DbSet<Users> GetManagers()
        {
            return _context.Users;
        }

        public DbSet<Accounts> GetReceivers()
        {
            return _context.Accounts;
        }

        public DbSet<Accounts> GetSenders()
        {
            return _context.Accounts;
        }
    }
}
