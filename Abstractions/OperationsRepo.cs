using BankManagementSystem.Data;
using BankManagementSystem.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BankManagementSystem.Abstractions
{
    public class OperationsRepo: IOperationsRepo
    {
        readonly BankContext _context;
        public OperationsRepo(BankContext context)
        {
            _context = context;
        }

        public void Add(Operations operation)
        {
            _context.Add(operation);
        }

        public void Update(Operations operation)
        {
            _context.Update(operation);
        }

        public void Delete(Operations operation)
        {
            _context.Remove(operation);
        }

        public bool Exist(int id)
        {
            return _context.Operations.Any(m => m.id == id);
        }

        public Task<List<Operations>> GetAll()
        {
            return _context.Operations.ToListAsync();
        }

        public Task<Operations> GetDetail(int? id)
        {
            return _context.Operations.FirstOrDefaultAsync(m => m.id == id);
        }

        public Task Save()
        {
            return _context.SaveChangesAsync();
        }
    }
}
