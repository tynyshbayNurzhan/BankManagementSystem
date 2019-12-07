using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using BankManagementSystem.Data;
using BankManagementSystem.Models;
using BankManagementSystem.Services;

namespace BankManagementSystem.Controllers
{
    public class OperationsController : Controller
    {
        private readonly OperationsService _operationsService;

        public OperationsController(OperationsService operationsService)
        {
            _operationsService = operationsService;
        }

        // GET: Operations
        public async Task<IActionResult> Index()
        {
            return View(await _operationsService.GetOperations());
        }

        // GET: Operations/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var operations = await _operationsService.DetailsOperations(id);
            if (operations == null)
            {
                return NotFound();
            }

            return View(operations);
        }

        // GET: Operations/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Operations/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("id,name")] Operations operations)
        {
            if (ModelState.IsValid)
            {
                await _operationsService.AddAndSave(operations);
            }
            return View(operations);
        }

        // GET: Operations/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var operations = await _operationsService.DetailsOperations(id);
            if (operations == null)
            {
                return NotFound();
            }
            return View(operations);
        }

        // POST: Operations/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("id,name")] Operations operations)
        {
            if (id != operations.id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    await _operationsService.Update(operations);
                   
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!OperationsExists(operations.id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(operations);
        }

        // GET: Operations/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var operations = await _operationsService.DetailsOperations(id);
            if (operations == null)
            {
                return NotFound();
            }

            return View(operations);
        }

        // POST: Operations/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var operations = await _operationsService.DetailsOperations(id);
            await _operationsService.Delete(operations);
            
            return RedirectToAction(nameof(Index));
        }

        private bool OperationsExists(int id)
        {
            return _operationsService.OperationsExis(id);
        }
    }
}
