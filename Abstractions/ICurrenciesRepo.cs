using BankManagementSystem.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BankManagementSystem.Abstractions
{
    public interface ICurrenciesRepo
    {
        void Add(Currencies currencies);
        void Update(Currencies currencies);
        void Delete(Currencies currencies);
        Task Save();
        Task<List<Currencies>> GetAll();
        Task<Currencies> GetDetail(int? id);
        bool Exist(int id);
        DbSet<BankTotalBalance> GetBankTotals();
        DbSet<CurrencyExchange> GetCurrencyExchange();
    }
}
