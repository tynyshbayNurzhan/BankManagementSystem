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
    public class CurrenciesController : Controller
    {
        private readonly CurrenciesService _currenciesService;

        public CurrenciesController(CurrenciesService currenciesService)
        {
            _currenciesService = currenciesService;
        }

        // GET: Currencies
        public async Task<IActionResult> Index()
        {
            var currencies = await _currenciesService.GetCurrency();
            return View(currencies);
        }

        // GET: Currencies/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var currencies = await _currenciesService.GetCurrency();
            if (currencies == null)
            {
                return NotFound();
            }

            return View(currencies);
        }

        // GET: Currencies/Create
        public IActionResult Create()
        {
            ViewData["bank_total_balance_id"] = new SelectList(_currenciesService.GetBankTotals(), "id", "id");
            ViewData["currency_exchange_id"] = new SelectList(_currenciesService.GetCurrencyExchange(), "id", "id");
            return View();
        }

        // POST: Currencies/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("id,name,short_name,currency_exchange_id,bank_total_balance_id")] Currencies currencies)
        {
            if (ModelState.IsValid)
            {
                await _currenciesService.AddAndUpdate(currencies);
                
                return RedirectToAction(nameof(Index));
            }
            ViewData["bank_total_balance_id"] = new SelectList(_currenciesService.GetBankTotals(), "id", "id", currencies.bank_total_balance_id);
            ViewData["currency_exchange_id"] = new SelectList(_currenciesService.GetCurrencyExchange(), "id", "id", currencies.currency_exchange_id);
            return View(currencies);
        }

        // GET: Currencies/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var currencies = await _currenciesService.DetailsCurrencies(id);
            if (currencies == null)
            {
                return NotFound();
            }
            ViewData["bank_total_balance_id"] = new SelectList(_currenciesService.GetBankTotals(), "id", "id", currencies.bank_total_balance_id);
            ViewData["currency_exchange_id"] = new SelectList(_currenciesService.GetCurrencyExchange(), "id", "id", currencies.currency_exchange_id);
            return View(currencies);
        }

        // POST: Currencies/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("id,name,short_name,currency_exchange_id,bank_total_balance_id")] Currencies currencies)
        {
            if (id != currencies.id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    await _currenciesService.Update(currencies);
                    
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CurrenciesExists(currencies.id))
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
            ViewData["bank_total_balance_id"] = new SelectList(_currenciesService.GetBankTotals(), "id", "id", currencies.bank_total_balance_id);
            ViewData["currency_exchange_id"] = new SelectList(_currenciesService.GetCurrencyExchange(), "id", "id", currencies.currency_exchange_id);
            return View(currencies);
        }

        // GET: Currencies/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var currencies = await _currenciesService.DetailsCurrencies(id);
                
            if (currencies == null)
            {
                return NotFound();
            }

            return View(currencies);
        }

        // POST: Currencies/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var currencies = await _currenciesService.DetailsCurrencies(id);
            await _currenciesService.Delete(currencies);
            
            return RedirectToAction(nameof(Index));
        }

        private bool CurrenciesExists(int id)
        {
            return _currenciesService.CurrenciesExis(id);
        }
    }
}
