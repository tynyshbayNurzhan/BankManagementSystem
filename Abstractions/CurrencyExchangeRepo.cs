using BankManagementSystem.Data;
using BankManagementSystem.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BankManagementSystem.Abstractions
{
    public class CurrencyExchangeRepo: ICurrencyExchangeRepo
    {
        readonly BankContext _context;
        public CurrencyExchangeRepo(BankContext context)
        {
            _context = context;
        }

        public void Add(CurrencyExchange currency_exchange)
        {
            _context.Add(currency_exchange);
        }

        public void Update(CurrencyExchange currency_exchange)
        {
            _context.Update(currency_exchange);
        }

        public void Delete(CurrencyExchange currency_exchange)
        {
            _context.Remove(currency_exchange);
        }

        public bool Exist(int id)
        {
            return _context.GetCurrencyExchanges.Any(m => m.id == id);
        }

        public Task<List<CurrencyExchange>> GetAll()
        {
            return _context.GetCurrencyExchanges.ToListAsync();
        }

        public Task<CurrencyExchange> GetDetail(int? id)
        {
            return _context.GetCurrencyExchanges.FirstOrDefaultAsync(m => m.id == id);
        }

        public Task Save()
        {
            return _context.SaveChangesAsync();
        }
    }
    
}
