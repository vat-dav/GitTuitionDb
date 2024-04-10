using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using TuitionDb.Areas.Identity.Data;
using TuitionDbv1.Models;


namespace TuitionDbv1.Controllers
{
    [Authorize]
    public class BatchesController : Controller
    {
        
        private readonly TuitionDbContext _context;

        public BatchesController(TuitionDbContext context)
        {
            _context = context;
        }

        // GET: Batchs
        public async Task<IActionResult> Index()
        {
            var tuitionDbContext = _context.Batches.Include(b => b.Staffs);
            return View(await tuitionDbContext.ToListAsync());
        }

        // GET: Batchs/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var batch = await _context.Batches
                .Include(b => b.Staffs)
                .FirstOrDefaultAsync(m => m.BatchId == id);
            if (batch == null)
            {
                return NotFound();
            }

            return View(batch);
        }

        // GET: Batchs/Create
        public IActionResult Create()
        {
            ViewData["StaffId"] = new SelectList(_context.Staffs, "StaffId", "StaffId");
            ViewBag.SubjectId = new SelectList(_context.Subjects, "SubjectId", "SubjectId");
            

            return View();
        }

        // POST: Batchs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("BatchId,BatchDay,BatchTime,BatchNotes,StaffId,SubjectId")] Batch batch)
        {
            if (!ModelState.IsValid)
            {
                _context.Add(batch);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["StaffId"] = new SelectList(_context.Staffs, "StaffId", "StaffId", batch.StaffId);
            ViewBag.SubjectId = new SelectList(_context.Subjects, "SubjectId", "SubjectId");
            return View(batch);
        }

        // GET: Batchs/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var batch = await _context.Batches.FindAsync(id);
            if (batch == null)
            {
                return NotFound();
            }
            ViewData["StaffId"] = new SelectList(_context.Staffs, "StaffId", "StaffId", batch.StaffId);
            ViewBag.SubjectId = new SelectList(_context.Subjects, "SubjectId", "SubjectId");
            return View(batch);
        }

        // POST: Batchs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("BatchId,BatchDay,BatchTime,BatchNotes,StaffId,SubjectId")] Batch batch)
        {
            if (id != batch.BatchId)
            {
                return NotFound();
            }

            if (!ModelState.IsValid)
            {
                try
                {
                    _context.Update(batch);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BatchExists(batch.BatchId))
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
            ViewData["StaffId"] = new SelectList(_context.Staffs, "StaffId", "StaffId", batch.StaffId);
            return View(batch);
        }

        // GET: Batchs/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var batch = await _context.Batches
                .Include(b => b.Staffs)
                .FirstOrDefaultAsync(m => m.BatchId == id);
            if (batch == null)
            {
                return NotFound();
            }

            return View(batch);
        }

        // POST: Batchs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var batch = await _context.Batches.FindAsync(id);
            if (batch != null)
            {
                _context.Batches.Remove(batch);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool BatchExists(int id)
        {
            return _context.Batches.Any(e => e.BatchId == id);
        }
    }
}
