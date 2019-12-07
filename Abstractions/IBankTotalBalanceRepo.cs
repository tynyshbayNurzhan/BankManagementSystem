using BankManagementSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BankManagementSystem.Abstractions
{
    public interface IBankTotalBalanceRepo
    {
        void Add(BankTotalBalance bankTotalBalance);
        void Update(BankTotalBalance bankTotalBalance);
        void Delete(BankTotalBalance bankTotalBalance);
        Task Save();
        Task<List<BankTotalBalance>> GetAll();
        Task<BankTotalBalance> GetDetail(int? id);
        bool Exist(int id);
    }
}
