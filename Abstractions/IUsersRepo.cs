using BankManagementSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BankManagementSystem.Abstractions
{
    public interface IUsersRepo
    {
        void Add(Users user);
        void Update(Users user);
        void Delete(Users user);
        Task Save();
        Task<List<Users>> GetAll();
        Task<Users> GetDetail(string id);
        bool Exist(string id);
        bool ExistByName(string name);
    }
}
