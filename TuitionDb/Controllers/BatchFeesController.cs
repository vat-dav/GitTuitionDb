using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using TuitionDb.Areas.Identity.Data;
using TuitionDbv1.Models;
using TuitionDb.Models;

namespace TuitionDb.Controllers
{
    [Authorize]
    public class BatchFeesController : Controller
    {

        private readonly TuitionDbContext _context;

        public BatchFeesController(TuitionDbContext context)
        {
            _context = context;
        }

        // GET: BatchFees
        public async Task<IActionResult> Index(string searchStudent)
        {
            
            int Bfr = await _context.BatchFee.CountAsync();
            ViewBag.Bfr = Bfr;

            var studentSearch = _context.Students.Where(a => a.StudentFirstName == searchStudent).FirstOrDefault();

            var batch = _context.BatchFee.Where(a => a.StudentId == studentSearch.StudentId);
            

            
            var batchFees = await _context.BatchFee
                                           .Include(bf => bf.Students) 
                                           .ToListAsync();

            return View(await batch.ToListAsync());
            
        }


        // GET: BatchFees/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var batchFee = await _context.BatchFee
                .Include(b => b.Students)
                .FirstOrDefaultAsync(m => m.FeeId == id);
            if (batchFee == null)
            {
                return NotFound();
            }
            var studentName = await _context.Students.FindAsync(batchFee.StudentId);
            if (studentName == null)

            {
                return NotFound();
            }

            ViewData["FullName"] = studentName.FullName;

            return View(batchFee);

         
        }
      

        // GET: BatchFees/Create
        public IActionResult Create()
        {
            ViewData["StudentId"] = new SelectList(_context.Students, "StudentId", "FullName", "StudentId","StudentId");
            return View();
        }

        // POST: BatchFees/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("FeeId,StudentId,AmountToPay,Received")] BatchFee batchFee)
        {
            if (!ModelState.IsValid)
            {
                _context.Add(batchFee);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["StudentId"] = new SelectList(_context.Students, "StudentId", "StudentId", batchFee.StudentId);
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
            
            ViewData["StudentId"] = new SelectList(_context.Students, "StudentId", "FullName", "StudentId", "StudentId");
    
            

            return View(batchFee);
        }



     
        // POST: BatchFees/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("FeeId,StudentId,AmountToPay,Received")] BatchFee batchFee)
        {
            if (id != batchFee.FeeId)
            {
                return NotFound();
            }

            if (!ModelState.IsValid)
            {
                try
                {
                    _context.Update(batchFee);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BatchFeeExists(batchFee.FeeId))
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
            ViewData["StudentId"] = new SelectList(_context.Students, "StudentId", "StudentId", batchFee.StudentId);
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
                .Include(b => b.Students)
                .FirstOrDefaultAsync(m => m.FeeId == id);
            if (batchFee == null)
            {
                return NotFound();
            }

            var studentName = await _context.Students.FindAsync(batchFee.StudentId);
            if (studentName == null)

            {
                return NotFound();
            }

            ViewData["FullName"] = studentName.FullName;


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
            return _context.BatchFee.Any(e => e.FeeId == id);
        }
    }

    
}