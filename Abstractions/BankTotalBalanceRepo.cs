using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BankManagementSystem.Data;
using BankManagementSystem.Models;
using Microsoft.EntityFrameworkCore;

namespace BankManagementSystem.Abstractions
{
    public class BankTotalBalanceRepo : IBankTotalBalanceRepo
    {
        readonly BankContext _context;

        public BankTotalBalanceRepo(BankContext context)
        {
            _context = context;
        }
        public void Add(BankTotalBalance bank_total_balance)
        {
            _context.Add(bank_total_balance);
        }

        public void Update(BankTotalBalance bank_total_balance)
        {
            _context.Update(bank_total_balance);
        }

        public void Delete(BankTotalBalance bank_total_balance)
        {
            _context.Remove(bank_total_balance);
        }

        public bool Exist(int id)
        {
            
            return _context.BankTotalBalances.Any(m => m.id == id);


        }



        public Task<List<BankTotalBalance>> GetAll()
        {
            return _context.BankTotalBalances.ToListAsync();
        }

        public Task<BankTotalBalance> GetDetail(int? id)
        {
            return _context.BankTotalBalances.FirstOrDefaultAsync(m => m.id == id);
        }

        public Task Save()
        {
            return _context.SaveChangesAsync();
        }
    }
}
