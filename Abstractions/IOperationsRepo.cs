using BankManagementSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BankManagementSystem.Abstractions
{
    public interface IOperationsRepo
    {
        void Add(Operations operation);
        void Update(Operations operation);
        void Delete(Operations operation);
        Task Save();
        Task<List<Operations>> GetAll();
        Task<Operations> GetDetail(int? id);
        bool Exist(int id);
    }
}
