using BankManagementSystem.Abstractions;
using BankManagementSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BankManagementSystem.Services
{
    public class BankTotalBalanceService
    {
        private readonly IBankTotalBalanceRepo _bankTotalBalanceRepo;
        public BankTotalBalanceService(IBankTotalBalanceRepo bankTotalBalanceRepo)
        {
            _bankTotalBalanceRepo = bankTotalBalanceRepo;
        }

        // GET: Roles
        public async Task<List<BankTotalBalance>> GetBankTotals()
        {
            return await _bankTotalBalanceRepo.GetAll();
        }

        // GET: Roles/Details/5 and For Edit Get Role
        public async Task<BankTotalBalance> DetailsBankTotals(int? id)
        {
            return await _bankTotalBalanceRepo.GetDetail(id);
        }
        // For last method
        public bool BankTotalsExis(int id)
        {
            return _bankTotalBalanceRepo.Exist(id);
        }
        // POST: Roles/Create
        public async Task AddAndSave(BankTotalBalance bank_total_balance)
        {
            _bankTotalBalanceRepo.Add(bank_total_balance);
            await _bankTotalBalanceRepo.Save();
        }

        // POST: Roles/Edit/5
        public async Task Update(BankTotalBalance bank_total_balance)
        {
            _bankTotalBalanceRepo.Update(bank_total_balance);
            await _bankTotalBalanceRepo.Save();
        }

        // POST: Roles/Delete/5
        public async Task Delete(BankTotalBalance bank_total_balance)
        {
            _bankTotalBalanceRepo.Delete(bank_total_balance);
            await _bankTotalBalanceRepo.Save();
        }
    }
}
