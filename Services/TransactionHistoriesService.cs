using BankManagementSystem.Abstractions;
using BankManagementSystem.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BankManagementSystem.Services
{
    public class TransactionHistoriesService
    {
        private readonly ITransactionHistoriesRepo _transactionsRepo;
        public TransactionHistoriesService(ITransactionHistoriesRepo transactionsRepo)
        {
            _transactionsRepo = transactionsRepo;
        }

        // GET: Roles
        public async Task<List<TransactionHistories>> GetTransaction()
        {
            return await _transactionsRepo.GetAll();
        }

        // GET: Roles/Details/5 and For Edit Get Role
        public async Task<TransactionHistories> DetailsTransactions(int? id)
        {
            return await _transactionsRepo.GetDetail(id);
        }
        // For last method
        public bool TransactionExis(int id)
        {
            return _transactionsRepo.Exist(id);
        }
        // POST: Roles/Create
        public async Task AddAndSave(TransactionHistories transaction_histories)
        {
            _transactionsRepo.Add(transaction_histories);
            await _transactionsRepo.Save();
        }

        // POST: Roles/Edit/5
        public async Task Update(TransactionHistories transaction_histories)
        {
            _transactionsRepo.Update(transaction_histories);
            await _transactionsRepo.Save();
        }

        // POST: Roles/Delete/5
        public async Task Delete(TransactionHistories transaction_histories)
        {
            _transactionsRepo.Delete(transaction_histories);
            await _transactionsRepo.Save();
        }

        public DbSet<Currencies> getCurrencies()
        {
            return _transactionsRepo.GetCurrencies();
        }

        public DbSet<Operations> getOperations()
        {
            return _transactionsRepo.GetOperations();
        }

        public DbSet<Users> getManagers()
        {
            return _transactionsRepo.GetManagers();
        }

        public DbSet<Accounts> getReceivers()
        {
            return _transactionsRepo.GetReceivers();
        }

        public DbSet<Accounts> getSenders()
        {
            return _transactionsRepo.GetSenders();
        }
    }
}
