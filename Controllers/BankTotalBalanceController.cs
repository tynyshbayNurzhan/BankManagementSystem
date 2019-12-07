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
    public class BankTotalBalanceController : Controller
    {
        private readonly BankTotalBalanceService _bankTotalBalanceService;

        public BankTotalBalanceController(BankTotalBalanceService bankTotalBalanceService)
        {
            _bankTotalBalanceService = bankTotalBalanceService;
        }

        // GET: BankTotalBalance
        public async Task<IActionResult> Index()
        {
            return View(await _bankTotalBalanceService.GetBankTotals());
        }

        // GET: BankTotalBalance/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var bankTotalBalance = await _bankTotalBalanceService.DetailsBankTotals(id);
                
            if (bankTotalBalance == null)
            {
                return NotFound();
            }

            return View(bankTotalBalance);
        }

        // GET: BankTotalBalance/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: BankTotalBalance/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("id,value,currency_id")] BankTotalBalance bankTotalBalance)
        {
            if (ModelState.IsValid)
            {
                await _bankTotalBalanceService.AddAndSave(bankTotalBalance);
               
                return RedirectToAction(nameof(Index));
            }
            return View(bankTotalBalance);
        }

        // GET: BankTotalBalance/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var bankTotalBalance = await _bankTotalBalanceService.DetailsBankTotals(id);
            if (bankTotalBalance == null)
            {
                return NotFound();
            }
            return View(bankTotalBalance);
        }

        // POST: BankTotalBalance/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("id,value,currency_id")] BankTotalBalance bankTotalBalance)
        {
            if (id != bankTotalBalance.id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    await _bankTotalBalanceService.Update(bankTotalBalance);
                   
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BankTotalBalanceExists(bankTotalBalance.id))
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
            return View(bankTotalBalance);
        }

        // GET: BankTotalBalance/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var bankTotalBalance = await _bankTotalBalanceService.DetailsBankTotals(id);
                
            if (bankTotalBalance == null)
            {
                return NotFound();
            }

            return View(bankTotalBalance);
        }

        // POST: BankTotalBalance/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var bankTotalBalance = await _bankTotalBalanceService.DetailsBankTotals(id);
            await _bankTotalBalanceService.Delete(bankTotalBalance);
            
            return RedirectToAction(nameof(Index));
        }

        private bool BankTotalBalanceExists(int id)
        {
            return _bankTotalBalanceService.BankTotalsExis(id);
        }
    }
}
