using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BankManagementSystem.Data;
using BankManagementSystem.Models;
using Microsoft.EntityFrameworkCore;

namespace BankManagementSystem.Abstractions
{
    public class CurrenciesRepo : ICurrenciesRepo
    {
        readonly BankContext _context;
        public CurrenciesRepo(BankContext context)
        {
            _context = context;
        }

        public void Add(Currencies currencies)
        {
            _context.Add(currencies);
        }

        public void Update(Currencies currencies)
        {
            _context.Update(currencies);
        }

        public void Delete(Currencies currencies)
        {
            _context.Remove(currencies);
        }

        public bool Exist(int id)
        {
            return _context.Currencies.Any(m => m.id == id);
        }

        public Task<List<Currencies>> GetAll()
        {
            return _context.Currencies.ToListAsync();
        }

        public Task<Currencies> GetDetail(int? id)
        {
            return _context.Currencies.FirstOrDefaultAsync(m => m.id == id);
        }

        public Task Save()
        {
            return _context.SaveChangesAsync();
        }

        public DbSet<BankTotalBalance> GetBankTotals()
        {
            return _context.BankTotalBalances;
        }

        public DbSet<CurrencyExchange> GetCurrencyExchange()
        {
            return _context.GetCurrencyExchanges;
        }

    }
}
