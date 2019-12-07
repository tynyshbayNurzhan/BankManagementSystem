using BankManagementSystem.Abstractions;
using BankManagementSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BankManagementSystem.Services
{
    public class UsersService
    {
        private readonly IUsersRepo _userRepo;
        public UsersService(IUsersRepo userRepo)
        {
            _userRepo = userRepo;
        }

        
        public async Task<List<Users>> GetUser()
        {
            return await _userRepo.GetAll();
            //return await _context.Roles.ToListAsync();
        }

        
        public async Task<Users> DetailsUsers(string id)
        {
            return await _userRepo.GetDetail(id);
            //return await _context.Roles.FirstOrDefaultAsync(m => m.Id == id);
        }
        
        public bool UserExis(string id)
        {
            return _userRepo.Exist(id);
            //return _context.Roles.Any(m => m.Id == id);
        }

        public bool UserExisByName(string full_name)
        {
            return _userRepo.ExistByName(full_name);
        }
        
        public async Task AddAndSave(Users user)
        {
            _userRepo.Add(user);
            await _userRepo.Save();
            //_context.Roles.Add(role);
            //await _context.SaveChangesAsync();
        }

        
        public async Task Update(Users user)
        {
            _userRepo.Update(user);
            await _userRepo.Save();
            //_context.Roles.Update(role);
            //await _context.SaveChangesAsync();
        }

        
        public async Task Delete(Users user)
        {
            _userRepo.Delete(user);
            await _userRepo.Save();
            //_context.Roles.Remove(role);
            //await _context.SaveChangesAsync();
        }
    }
}
