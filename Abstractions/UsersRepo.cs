using BankManagementSystem.Data;
using BankManagementSystem.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BankManagementSystem.Abstractions
{
    public class UsersRepo: IUsersRepo
    {
        readonly BankContext _context;
        public UsersRepo(BankContext context)
        {
            _context = context;
        }

        public void Add(Users user)
        {
            _context.Add(user);
        }

        public void Update(Users user)
        {
            _context.Update(user);
        }

        public void Delete(Users user)
        {
            _context.Remove(user);
        }

        public bool Exist(string id)
        {
            return _context.Users.Any(m => m.Id == id);
        }

        public bool ExistByName(string full_name)
        {
            return _context.Users.Any(m => m.full_name == full_name);
        }

        public Task<List<Users>> GetAll()
        {
            return _context.Users.ToListAsync();
        }

        public Task<Users> GetDetail(string id)
        {
            return _context.Users.FirstOrDefaultAsync(m => m.Id == id);
        }

        public Task Save()
        {
            return _context.SaveChangesAsync();
        }

    }
}
