using BankManagementSystem.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BankManagementSystem.Abstractions
{
    public interface ITransactionHistoriesRepo
    {
        void Add(TransactionHistories transaction_histories);
        void Update(TransactionHistories transaction_histories);
        void Delete(TransactionHistories transaction_histories);
        Task Save();
        Task<List<TransactionHistories>> GetAll();
        Task<TransactionHistories> GetDetail(int? id);
        bool Exist(int id);
        DbSet<Currencies> GetCurrencies();
        DbSet<Operations> GetOperations();
        DbSet<Accounts> GetReceivers();
        DbSet<Accounts> GetSenders();
        DbSet<Users> GetManagers();
    }
}
