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
    public class TransactionHistoriesController : Controller
    {
        private readonly TransactionHistoriesService _transactionsService;

        public TransactionHistoriesController(TransactionHistoriesService transactionsService)
        {
            _transactionsService = transactionsService;
        }

        // GET: TransactionHistories
        public async Task<IActionResult> Index()
        {
            var transactionHistories = await _transactionsService.GetTransaction();
            return View(transactionHistories);
        }

        // GET: TransactionHistories/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var transactionHistories = await _transactionsService.DetailsTransactions(id);
            if (transactionHistories == null)
            {
                return NotFound();
            }

            return View(transactionHistories);
        }

        // GET: TransactionHistories/Create
        public IActionResult Create()
        {
            ViewData["currency_id"] = new SelectList(_transactionsService.getCurrencies(), "id", "name");
            ViewData["manager_id"] = new SelectList(_transactionsService.getManagers(), "id", "full_name");
            ViewData["operation_id"] = new SelectList(_transactionsService.getOperations(), "id", "name");
            ViewData["receiver_account_id"] = new SelectList(_transactionsService.getReceivers(), "id", "first_name");
            ViewData["sender_account_id"] = new SelectList(_transactionsService.getSenders(), "id", "first_name");
            return View();
        }

        // POST: TransactionHistories/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("id,manager_id,sender_account_id,receiver_account_id,operation_id,currency_id,amount,operation_time")] TransactionHistories transactionHistories)
        {
            if (ModelState.IsValid)
            {
                await _transactionsService.AddAndSave(transactionHistories);
            }
            ViewData["currency_id"] = new SelectList(_transactionsService.getCurrencies(), "id", "name", transactionHistories.currency_id);
            //ViewData["manager_id"] = new SelectList(_transactionsService.getManagers(), "id", "full_name", transactionHistories.manager_id);
            ViewData["operation_id"] = new SelectList(_transactionsService.getOperations(), "id", "name", transactionHistories.operation_id);
            ViewData["receiver_account_id"] = new SelectList(_transactionsService.getReceivers(), "id", "first_name", transactionHistories.receiver_account_id);
            ViewData["sender_account_id"] = new SelectList(_transactionsService.getSenders(), "id", "first_name", transactionHistories.sender_account_id);
            return View(transactionHistories);
        }

        // GET: TransactionHistories/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var transactionHistories = await _transactionsService.DetailsTransactions(id);
            if (transactionHistories == null)
            {
                return NotFound();
            }
            ViewData["currency_id"] = new SelectList(_transactionsService.getCurrencies(), "id", "name", transactionHistories.currency_id);
            //ViewData["manager_id"] = new SelectList(_transactionsService.getManagers(), "id", "full_name", transactionHistories.manager_id);
            ViewData["operation_id"] = new SelectList(_transactionsService.getOperations(), "id", "name", transactionHistories.operation_id);
            ViewData["receiver_account_id"] = new SelectList(_transactionsService.getReceivers(), "id", "first_name", transactionHistories.receiver_account_id);
            ViewData["sender_account_id"] = new SelectList(_transactionsService.getSenders(), "id", "first_name", transactionHistories.sender_account_id);
            return View(transactionHistories);
        }

        // POST: TransactionHistories/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("id,/*manager_id,*/sender_account_id,receiver_account_id,operation_id,currency_id,amount,operation_time")] TransactionHistories transactionHistories)
        {
            if (id != transactionHistories.id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    await _transactionsService.Update(transactionHistories);
                    
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TransactionHistoriesExists(transactionHistories.id))
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
            ViewData["currency_id"] = new SelectList(_transactionsService.getCurrencies(), "id", "name", transactionHistories.currency_id);
            //ViewData["manager_id"] = new SelectList(_transactionsService.getManagers(), "id", "full_name", transactionHistories.manager_id);
            ViewData["operation_id"] = new SelectList(_transactionsService.getOperations(), "id", "name", transactionHistories.operation_id);
            ViewData["receiver_account_id"] = new SelectList(_transactionsService.getReceivers(), "id", "first_name", transactionHistories.receiver_account_id);
            ViewData["sender_account_id"] = new SelectList(_transactionsService.getSenders(), "id", "first_name", transactionHistories.sender_account_id);
            return View(transactionHistories);
        }

        // GET: TransactionHistories/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var transactionHistories = await _transactionsService.DetailsTransactions(id);
            if (transactionHistories == null)
            {
                return NotFound();
            }

            return View(transactionHistories);
        }

        // POST: TransactionHistories/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var transactionHistories = await _transactionsService.DetailsTransactions(id);
            await _transactionsService.Delete(transactionHistories);
            
            return RedirectToAction(nameof(Index));
        }

        private bool TransactionHistoriesExists(int id)
        {
            return _transactionsService.TransactionExis(id);
        }
    }
}
