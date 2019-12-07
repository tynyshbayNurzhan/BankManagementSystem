using BankManagementSystem.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BankManagementSystem.Abstractions
{
    public interface IAccountsRepo
    {
        void Add(Accounts accounts);
        void Update(Accounts accounts);
        void Delete(Accounts accounts);
        Task Save();
        Task<List<Accounts>> GetAll();
        Task<Accounts> GetDetail(int? id);
        bool Exist(int id);
        DbSet<Currencies> GetCurrencies();
    }
}
