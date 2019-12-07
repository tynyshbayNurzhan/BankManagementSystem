using BankManagementSystem.Abstractions;
using BankManagementSystem.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BankManagementSystem.Services
{
    public class AccountsService
    {
        private readonly IAccountsRepo _accountsRepo;
        public AccountsService(IAccountsRepo accountsRepo)
        {
            _accountsRepo = accountsRepo;
        }

        
        public async Task<List<Accounts>> GetAccount()
        {
            return await _accountsRepo.GetAll();
        }

       
        public async Task<Accounts> DetailsAccounts(int? id)
        {
            return await _accountsRepo.GetDetail(id);
        }
        
        public bool AccountsExis(int id)
        {
            return _accountsRepo.Exist(id);
        }
        
        public async Task AddAndSave(Accounts accounts)
        {
            _accountsRepo.Add(accounts);
            await _accountsRepo.Save();
        }

        
        public async Task Update(Accounts accounts)
        {
            _accountsRepo.Update(accounts);
            await _accountsRepo.Save();
        }

        
        public async Task Delete(Accounts accounts)
        {
            _accountsRepo.Delete(accounts);
            await _accountsRepo.Save();
        }

        public DbSet<Currencies> getCurrencies()
        {
            return _accountsRepo.GetCurrencies();
        }
    }
}
