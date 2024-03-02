using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ServerFinder.Context;
using ServerFinder.Entities;

namespace ServerFinder.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Policy = "IPAuth")]
    public class CompanyController : Controller
    {
        private readonly MainDbContext _context;

        public CompanyController(MainDbContext context)
        {
            _context = context;
        }

        // GET: Admin/Company
        public async Task<IActionResult> Index()
        {
            return View(await _context.TblCompanies.ToListAsync());
        }

        // GET: Admin/Company/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tblCompany = await _context.TblCompanies
                .FirstOrDefaultAsync(m => m.Id == id);
            if (tblCompany == null)
            {
                return NotFound();
            }

            return View(tblCompany);
        }

        // GET: Admin/Company/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Admin/Company/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,CompanyName,Website")] TblCompany tblCompany)
        {
            if (ModelState.IsValid)
            {
                _context.Add(tblCompany);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(tblCompany);
        }

        // GET: Admin/Company/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tblCompany = await _context.TblCompanies.FindAsync(id);
            if (tblCompany == null)
            {
                return NotFound();
            }
            return View(tblCompany);
        }

        // POST: Admin/Company/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,CompanyName,Website")] TblCompany tblCompany)
        {
            if (id != tblCompany.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tblCompany);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TblCompanyExists(tblCompany.Id))
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
            return View(tblCompany);
        }

        // GET: Admin/Company/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tblCompany = await _context.TblCompanies
                .FirstOrDefaultAsync(m => m.Id == id);
            if (tblCompany == null)
            {
                return NotFound();
            }

            return View(tblCompany);
        }

        // POST: Admin/Company/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var tblCompany = await _context.TblCompanies.FindAsync(id);
            if (tblCompany != null)
            {
                _context.TblCompanies.Remove(tblCompany);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TblCompanyExists(int id)
        {
            return _context.TblCompanies.Any(e => e.Id == id);
        }
    }
}
