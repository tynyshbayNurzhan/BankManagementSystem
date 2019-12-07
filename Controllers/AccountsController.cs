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
    public class AccountsController : Controller
    {
        private readonly AccountsService _accountsService;

        public AccountsController(AccountsService accountsService)
        {
            _accountsService = accountsService;
        }

        // GET: Accounts
        public async Task<IActionResult> Index()
        {
            var accounts = await _accountsService.GetAccount();
            return View(accounts);
        }

        // GET: Accounts/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var accounts = await _accountsService.DetailsAccounts(id);
            if (accounts == null)
            {
                return NotFound();
            }

            return View(accounts);
        }

        // GET: Accounts/Create
        public IActionResult Create()
        {
            ViewData["currency_id"] = new SelectList(_accountsService.getCurrencies(), "id", "name");
            return View();
        }

        // POST: Accounts/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("id,name,first_name,last_name,amount,created_date,is_blocked,currency_id")] Accounts accounts)
        {
            if (ModelState.IsValid)
            {
                await _accountsService.AddAndSave(accounts);
                return RedirectToAction(nameof(Index));
            }
            ViewData["currency_id"] = new SelectList(_accountsService.getCurrencies(), "id", "name", accounts.currency_id);
            return View(accounts);
        }

        // GET: Accounts/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var accounts = await _accountsService.DetailsAccounts(id);
            if (accounts == null)
            {
                return NotFound();
            }
            ViewData["currency_id"] = new SelectList(_accountsService.getCurrencies(), "id", "name", accounts.currency_id);
            return View(accounts);
        }

        // POST: Accounts/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("id,name,first_name,last_name,amount,created_date,is_blocked,currency_id")] Accounts accounts)
        {
            if (id != accounts.id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    await _accountsService.Update(accounts);
          
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AccountsExists(accounts.id))
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
            ViewData["currency_id"] = new SelectList(_accountsService.getCurrencies(), "id", "name", accounts.currency_id);
            return View(accounts);
        }

        // GET: Accounts/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var accounts = await _accountsService.DetailsAccounts(id);
            if (accounts == null)
            {
                return NotFound();
            }

            return View(accounts);
        }

        // POST: Accounts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var accounts = await _accountsService.DetailsAccounts(id);
            await _accountsService.Delete(accounts);
             
            return RedirectToAction(nameof(Index));
        }

        private bool AccountsExists(int id)
        {
            return _accountsService.AccountsExis(id);
        }
    }
}
