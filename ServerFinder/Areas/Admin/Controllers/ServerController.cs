using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ServerFinder.Context;
using ServerFinder.Entities;

namespace ServerFinder.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ServerController : Controller
    {
        private readonly MainDbContext _context;

        public ServerController(MainDbContext context)
        {
            _context = context;
        }

        // GET: Admin/Server
        public async Task<IActionResult> Index()
        {
            var mainDbContext = _context.TblServers.Include(t => t.CompanyNavigation).Include(t => t.ProcessorNavigation);
            return View(await mainDbContext.ToListAsync());
        }

        // GET: Admin/Server/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tblServer = await _context.TblServers
                .Include(t => t.CompanyNavigation)
                .Include(t => t.ProcessorNavigation)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (tblServer == null)
            {
                return NotFound();
            }

            return View(tblServer);
        }

        // GET: Admin/Server/Create
        public IActionResult Create()
        {
            ViewData["Company"] = new SelectList(_context.TblCompanies, "Id", "CompanyName");
            ViewData["Processor"] = new SelectList(_context.TblProcessors, "Id", "ProcessorName");
            return View();
        }

        // POST: Admin/Server/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,ServerName,Ram,IsEcc,Storage,TotalStorage,ConnectionSpeed,Bandwidth,IsCustomisable,Link,Company,Processor,ProcessorCount,Price,Currency")] TblServer tblServer)
        {
            if (ModelState.IsValid)
            {
                _context.Add(tblServer);
                
                var priceInEuros = 0m;
                if (tblServer.Currency.ToUpper() == "EUR")
                {
                    priceInEuros = tblServer.Price;
                }
                else
                {
                    priceInEuros = tblServer.Price / (decimal)_context.TblRates.First(k => k.Currency == tblServer.Currency.ToUpper()).Rate;
                }

                tblServer.PriceGbp = priceInEuros * (decimal)_context.TblRates.First(k => k.Currency == "EUR").Rate;
                
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["Company"] = new SelectList(_context.TblCompanies, "Id", "CompanyName", tblServer.Company);
            ViewData["Processor"] = new SelectList(_context.TblProcessors, "Id", "ProcessorName", tblServer.Processor);
            return View(tblServer);
        }

        // GET: Admin/Server/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tblServer = await _context.TblServers.FindAsync(id);
            if (tblServer == null)
            {
                return NotFound();
            }
            ViewData["Company"] = new SelectList(_context.TblCompanies, "Id", "CompanyName", tblServer.Company);
            ViewData["Processor"] = new SelectList(_context.TblProcessors, "Id", "ProcessorName", tblServer.Processor);
            return View(tblServer);
        }

        // POST: Admin/Server/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,ServerName,Ram,IsEcc,Storage,TotalStorage,ConnectionSpeed,Bandwidth,IsCustomisable,Link,Company,Processor,ProcessorCount,Price,Currency")] TblServer tblServer)
        {
            if (id != tblServer.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tblServer);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TblServerExists(tblServer.Id))
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
            ViewData["Company"] = new SelectList(_context.TblCompanies, "Id", "Id", tblServer.Company);
            ViewData["Processor"] = new SelectList(_context.TblProcessors, "Id", "Id", tblServer.Processor);
            return View(tblServer);
        }

        // GET: Admin/Server/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tblServer = await _context.TblServers
                .Include(t => t.CompanyNavigation)
                .Include(t => t.ProcessorNavigation)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (tblServer == null)
            {
                return NotFound();
            }

            return View(tblServer);
        }

        // POST: Admin/Server/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var tblServer = await _context.TblServers.FindAsync(id);
            if (tblServer != null)
            {
                _context.TblServers.Remove(tblServer);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TblServerExists(int id)
        {
            return _context.TblServers.Any(e => e.Id == id);
        }
    }
}
