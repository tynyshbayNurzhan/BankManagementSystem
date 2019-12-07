using BankManagementSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BankManagementSystem.Abstractions
{
    public interface ICurrencyExchangeRepo
    {
        void Add(CurrencyExchange currency_exchange);
        void Update(CurrencyExchange currency_exchange);
        void Delete(CurrencyExchange currency_exchange);
        Task Save();
        Task<List<CurrencyExchange>> GetAll();
        Task<CurrencyExchange> GetDetail(int? id);
        bool Exist(int id);
    }
}
