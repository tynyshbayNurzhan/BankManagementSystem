using BankManagementSystem.Abstractions;
using BankManagementSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BankManagementSystem.Services
{
    public class OperationsService
    {
        private readonly IOperationsRepo _operationsRepo;
        public OperationsService(IOperationsRepo operationsRepo)
        {
            _operationsRepo = operationsRepo;
        }

        // GET: Roles
        public async Task<List<Operations>> GetOperations()
        {
            return await _operationsRepo.GetAll();
        }

        // GET: Roles/Details/5 and For Edit Get Role
        public async Task<Operations> DetailsOperations(int? id)
        {
            return await _operationsRepo.GetDetail(id);
        }
        // For last method
        public bool OperationsExis(int id)
        {
            return _operationsRepo.Exist(id);
        }
        // POST: Roles/Create
        public async Task AddAndSave(Operations operation)
        {
            _operationsRepo.Add(operation);
            await _operationsRepo.Save();
        }

        // POST: Roles/Edit/5
        public async Task Update(Operations operation)
        {
            _operationsRepo.Update(operation);
            await _operationsRepo.Save();
        }

        // POST: Roles/Delete/5
        public async Task Delete(Operations operation)
        {
            _operationsRepo.Delete(operation);
            await _operationsRepo.Save();
        }
    }
}
