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
    public class CurrencyExchangeController : Controller
    {
        private readonly CurrencyExchangeService _currenncyExchangeService;

        public CurrencyExchangeController(CurrencyExchangeService currenncyExchangeService)
        {
            _currenncyExchangeService = currenncyExchangeService;
        }

        // GET: CurrencyExchange
        public async Task<IActionResult> Index()
        {
            return View(await _currenncyExchangeService.GetCurrencyExchange());
        }

        // GET: CurrencyExchange/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var currencyExchange = await _currenncyExchangeService.DetailsCurrencyExchange(id);
            if (currencyExchange == null)
            {
                return NotFound();
            }

            return View(currencyExchange);
        }

        // GET: CurrencyExchange/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: CurrencyExchange/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("id,currency_id,purchase_value,sale_value,assigned_time")] CurrencyExchange currencyExchange)
        {
            if (ModelState.IsValid)
            {
                await _currenncyExchangeService.AddAndSave(currencyExchange);
            }
            return View(currencyExchange);
        }

        // GET: CurrencyExchange/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var currencyExchange = await _currenncyExchangeService.DetailsCurrencyExchange(id);
            if (currencyExchange == null)
            {
                return NotFound();
            }
            return View(currencyExchange);
        }

        // POST: CurrencyExchange/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("id,currency_id,purchase_value,sale_value,assigned_time")] CurrencyExchange currencyExchange)
        {
            if (id != currencyExchange.id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    await _currenncyExchangeService.Update(currencyExchange);
                   
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CurrencyExchangeExists(currencyExchange.id))
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
            return View(currencyExchange);
        }

        // GET: CurrencyExchange/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var currencyExchange = await _currenncyExchangeService.DetailsCurrencyExchange(id);
            if (currencyExchange == null)
            {
                return NotFound();
            }

            return View(currencyExchange);
        }

        // POST: CurrencyExchange/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var currencyExchange = await _currenncyExchangeService.DetailsCurrencyExchange(id);
            await _currenncyExchangeService.Delete(currencyExchange);
            
            return RedirectToAction(nameof(Index));
        }

        private bool CurrencyExchangeExists(int id)
        {
            return _currenncyExchangeService.CurrencyExchangeExis(id);
        }
    }
}
