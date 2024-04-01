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
    public class BatchSubjectsController : Controller
    {
        private readonly TuitionDbContext _context;

        public BatchSubjectsController(TuitionDbContext context)
        {
            _context = context;
        }

        // GET: BatchSubjects
        public async Task<IActionResult> Index()
        {
            return View(await _context.BatchSubject.ToListAsync());
        }

        // GET: BatchSubjects/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var batchSubject = await _context.BatchSubject
                .FirstOrDefaultAsync(m => m.SubjectId == id);
            if (batchSubject == null)
            {
                return NotFound();
            }

            return View(batchSubject);
        }

        // GET: BatchSubjects/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: BatchSubjects/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("SubjectId,SubjectName")] BatchSubject batchSubject)
        {
            if (ModelState.IsValid)
            {
                _context.Add(batchSubject);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(batchSubject);
        }

        // GET: BatchSubjects/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var batchSubject = await _context.BatchSubject.FindAsync(id);
            if (batchSubject == null)
            {
                return NotFound();
            }
            return View(batchSubject);
        }

        // POST: BatchSubjects/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("SubjectId,SubjectName")] BatchSubject batchSubject)
        {
            if (id != batchSubject.SubjectId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(batchSubject);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BatchSubjectExists(batchSubject.SubjectId))
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
            return View(batchSubject);
        }

        // GET: BatchSubjects/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var batchSubject = await _context.BatchSubject
                .FirstOrDefaultAsync(m => m.SubjectId == id);
            if (batchSubject == null)
            {
                return NotFound();
            }

            return View(batchSubject);
        }

        // POST: BatchSubjects/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var batchSubject = await _context.BatchSubject.FindAsync(id);
            if (batchSubject != null)
            {
                _context.BatchSubject.Remove(batchSubject);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool BatchSubjectExists(int id)
        {
            return _context.BatchSubject.Any(e => e.SubjectId == id);
        }
    }
}
