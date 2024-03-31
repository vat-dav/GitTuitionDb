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
    public class ClassFeesController : Controller
    {
        private readonly TuitionDbContext _context;

        public ClassFeesController(TuitionDbContext context)
        {
            _context = context;
        }

        // GET: ClassFees
        public async Task<IActionResult> Index()
        {
            return View(await _context.ClassFee.ToListAsync());
        }

        // GET: ClassFees/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var classFee = await _context.ClassFee
                .FirstOrDefaultAsync(m => m.FeesId == id);
            if (classFee == null)
            {
                return NotFound();
            }

            return View(classFee);
        }

        // GET: ClassFees/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: ClassFees/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("FeesId,ClassId,ParentId,StudentId,FeesPaid,PayMethod,PaymentDate")] ClassFee classFee)
        {
            if (ModelState.IsValid)
            {
                _context.Add(classFee);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(classFee);
        }

        // GET: ClassFees/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var classFee = await _context.ClassFee.FindAsync(id);
            if (classFee == null)
            {
                return NotFound();
            }
            return View(classFee);
        }

        // POST: ClassFees/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("FeesId,ClassId,ParentId,StudentId,FeesPaid,PayMethod,PaymentDate")] ClassFee classFee)
        {
            if (id != classFee.FeesId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(classFee);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ClassFeeExists(classFee.FeesId))
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
            return View(classFee);
        }

        // GET: ClassFees/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var classFee = await _context.ClassFee
                .FirstOrDefaultAsync(m => m.FeesId == id);
            if (classFee == null)
            {
                return NotFound();
            }

            return View(classFee);
        }

        // POST: ClassFees/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var classFee = await _context.ClassFee.FindAsync(id);
            if (classFee != null)
            {
                _context.ClassFee.Remove(classFee);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ClassFeeExists(int id)
        {
            return _context.ClassFee.Any(e => e.FeesId == id);
        }
    }
}
