using BankManagementSystem.Abstractions;
using BankManagementSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BankManagementSystem.Services
{
    public class CurrencyExchangeService
    {
        private readonly ICurrencyExchangeRepo _currencyExchangeRepo;
        public CurrencyExchangeService(ICurrencyExchangeRepo currencyExchangeRepo)
        {
            _currencyExchangeRepo = currencyExchangeRepo;
        }

        // GET: Roles
        public async Task<List<CurrencyExchange>> GetCurrencyExchange()
        {
            return await _currencyExchangeRepo.GetAll();
        }

        // GET: Roles/Details/5 and For Edit Get Role
        public async Task<CurrencyExchange> DetailsCurrencyExchange(int? id)
        {
            return await _currencyExchangeRepo.GetDetail(id);
        }
        // For last method
        public bool CurrencyExchangeExis(int id)
        {
            return _currencyExchangeRepo.Exist(id);
        }
        // POST: Roles/Create
        public async Task AddAndSave(CurrencyExchange currency_exchange)
        {
            _currencyExchangeRepo.Add(currency_exchange);
            await _currencyExchangeRepo.Save();
        }

        // POST: Roles/Edit/5
        public async Task Update(CurrencyExchange currency_exchange)
        {
            _currencyExchangeRepo.Update(currency_exchange);
            await _currencyExchangeRepo.Save();
        }

        // POST: Roles/Delete/5
        public async Task Delete(CurrencyExchange currency_exchange)
        {
            _currencyExchangeRepo.Delete(currency_exchange);
            await _currencyExchangeRepo.Save();
        }
    }
}
