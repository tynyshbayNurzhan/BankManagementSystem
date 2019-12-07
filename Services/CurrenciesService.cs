using BankManagementSystem.Abstractions;
using BankManagementSystem.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BankManagementSystem.Services
{
    public class CurrenciesService
    {
        private readonly ICurrenciesRepo _currenciesRepo;
        public CurrenciesService(ICurrenciesRepo currenciesRepo)
        {
            _currenciesRepo = currenciesRepo;
        }

        // GET: Roles
        public async Task<List<Currencies>> GetCurrency()
        {
            return await _currenciesRepo.GetAll();
        }

        // GET: Roles/Details/5 and For Edit Get Role
        public async Task<Currencies> DetailsCurrencies(int? id)
        {
            return await _currenciesRepo.GetDetail(id);
        }
        // For last method
        public bool CurrenciesExis(int id)
        {
            return _currenciesRepo.Exist(id);
        }
        // POST: Roles/Create
        public async Task AddAndUpdate(Currencies currencies)
        {
            _currenciesRepo.Add(currencies);
            await _currenciesRepo.Save();
        }

        // POST: Roles/Edit/5
        public async Task Update(Currencies currencies)
        {
            _currenciesRepo.Update(currencies);
            await _currenciesRepo.Save();
        }

        // POST: Roles/Delete/5
        public async Task Delete(Currencies currencies)
        {
            _currenciesRepo.Delete(currencies);
            await _currenciesRepo.Save();
        }

        public DbSet<BankTotalBalance> GetBankTotals()
        {
            return _currenciesRepo.GetBankTotals();
        }

        public DbSet<CurrencyExchange> GetCurrencyExchange()
        {
            return _currenciesRepo.GetCurrencyExchange();
        }
    }
}
