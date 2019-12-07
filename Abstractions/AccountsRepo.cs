using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BankManagementSystem.Data;
using BankManagementSystem.Models;
using Microsoft.EntityFrameworkCore;

namespace BankManagementSystem.Abstractions
{
    public class AccountsRepo : IAccountsRepo
    {
        readonly BankContext _context;
        public AccountsRepo(BankContext context)
        {
            _context = context;
        }

        public void Add(Accounts account)
        {
            _context.Add(account);
        }

        public void Update(Accounts account)
        {
            _context.Update(account);
        }

        public void Delete(Accounts account)
        {
            _context.Remove(account);
        }

        public bool Exist(int id)
        {
            return _context.Accounts.Any(m => m.id == id);
        }
        public Task<List<Accounts>> GetAll()
        {
            return _context.Accounts.ToListAsync();
        }

        public Task<Accounts> GetDetail(int? id)
        {
            return _context.Accounts.FirstOrDefaultAsync(m => m.id == id);
        }

        public Task Save()
        {
            return _context.SaveChangesAsync();
        }

        public DbSet<Currencies> GetCurrencies()
        {
            return _context.Currencies;
        }
    }
}
