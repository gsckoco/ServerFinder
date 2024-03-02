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
    public class ProcessorController : Controller
    {
        private readonly MainDbContext _context;

        public ProcessorController(MainDbContext context)
        {
            _context = context;
        }

        // GET: Admin/Processor
        public async Task<IActionResult> Index()
        {
            return View(await _context.TblProcessors.ToListAsync());
        }

        // GET: Admin/Processor/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tblProcessor = await _context.TblProcessors
                .FirstOrDefaultAsync(m => m.Id == id);
            if (tblProcessor == null)
            {
                return NotFound();
            }

            return View(tblProcessor);
        }

        // GET: Admin/Processor/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Admin/Processor/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,ProcessorName,PCores,ECores,PThreads,EThreads,BaseFreq,Brand")] TblProcessor tblProcessor)
        {
            if (ModelState.IsValid)
            {
                _context.Add(tblProcessor);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(tblProcessor);
        }

        // GET: Admin/Processor/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tblProcessor = await _context.TblProcessors.FindAsync(id);
            if (tblProcessor == null)
            {
                return NotFound();
            }
            return View(tblProcessor);
        }

        // POST: Admin/Processor/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,ProcessorName,PCores,ECores,PThreads,EThreads,BaseFreq,Brand")] TblProcessor tblProcessor)
        {
            if (id != tblProcessor.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tblProcessor);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TblProcessorExists(tblProcessor.Id))
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
            return View(tblProcessor);
        }

        // GET: Admin/Processor/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tblProcessor = await _context.TblProcessors
                .FirstOrDefaultAsync(m => m.Id == id);
            if (tblProcessor == null)
            {
                return NotFound();
            }

            return View(tblProcessor);
        }

        // POST: Admin/Processor/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var tblProcessor = await _context.TblProcessors.FindAsync(id);
            if (tblProcessor != null)
            {
                _context.TblProcessors.Remove(tblProcessor);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TblProcessorExists(int id)
        {
            return _context.TblProcessors.Any(e => e.Id == id);
        }
    }
}
