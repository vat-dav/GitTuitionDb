using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using TuitionDb.Areas.Identity.Data;
using TuitionDb.Models;

namespace TuitionDbv1.Controllers
{
    public class BatchFeesController : Controller
    {
        private readonly TuitionDbContext _context;

        public BatchFeesController(TuitionDbContext context)
        {
            _context = context;
        }

        // GET: BatchFees
        public async Task<IActionResult> Index()
        {
            return View(await _context.BatchFee.ToListAsync());
        }

        // GET: BatchFees/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var batchFee = await _context.BatchFee
                .FirstOrDefaultAsync(m => m.FeesId == id);
            if (batchFee == null)
            {
                return NotFound();
            }

            return View(batchFee);
        }

        // GET: BatchFees/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: BatchFees/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("FeesId,BatchId,ParentId,StudentId,FeesPaid,PayMethod,PaymentDate")] BatchFee batchFee)
        {
            if (ModelState.IsValid)
            {
                _context.Add(batchFee);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(batchFee);
        }

        // GET: BatchFees/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var batchFee = await _context.BatchFee.FindAsync(id);
            if (batchFee == null)
            {
                return NotFound();
            }
            return View(batchFee);
        }

        // POST: BatchFees/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("FeesId,BatchId,ParentId,StudentId,FeesPaid,PayMethod,PaymentDate")] BatchFee batchFee)
        {
            if (id != batchFee.FeesId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(batchFee);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BatchFeeExists(batchFee.FeesId))
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
            return View(batchFee);
        }

        // GET: BatchFees/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var batchFee = await _context.BatchFee
                .FirstOrDefaultAsync(m => m.FeesId == id);
            if (batchFee == null)
            {
                return NotFound();
            }

            return View(batchFee);
        }

        // POST: BatchFees/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var batchFee = await _context.BatchFee.FindAsync(id);
            if (batchFee != null)
            {
                _context.BatchFee.Remove(batchFee);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool BatchFeeExists(int id)
        {
            return _context.BatchFee.Any(e => e.FeesId == id);
        }
    }
}
