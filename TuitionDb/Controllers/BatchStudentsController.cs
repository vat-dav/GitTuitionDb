using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using TuitionDb.Areas.Identity.Data;
using TuitionDbv1.Models;

namespace TuitionDbv1.Controllers
{
    public class BatchStudentsController : Controller
    {
        private readonly TuitionDbContext _context;

        public BatchStudentsController(TuitionDbContext context)
        {
            _context = context;
        }

        // GET: BatchStudents
        public async Task<IActionResult> Index()
        {
            var tuitionDbContext = _context.BatchStudents.Include(b => b.Batches).Include(b => b.Students);

            return View(await tuitionDbContext.ToListAsync());


        }
        /*
        public async Task<IActionResult> StudentsInBatch(int batchId)
        {
            var students = await _context.BatchStudents
                .Where(bs => bs.BatchId == batchId)
                .Select(bs => bs.Students)
                .ToListAsync();

            return View(students);
        }

        */
            // GET: BatchStudents/Details/5
            public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var batchStudent = await _context.BatchStudents
                .Include(b => b.Batches)
                .Include(b => b.Students)
                .FirstOrDefaultAsync(m => m.BatchStudentId == id);
            if (batchStudent == null)
            {
                return NotFound();
            }

            return View(batchStudent);
        }

        // GET: BatchStudents/Create
        public IActionResult Create()
        {
            ViewData["BatchId"] = new SelectList(_context.Batches, "BatchId", "BatchId", "BatchId");
            
            ViewData["StudentId"] = new SelectList(_context.Students, "StudentId", "BillingAddress");
            return View();
        }

        // POST: BatchStudents/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("BatchStudentId,StudentId,BatchId,AmountToPay,Received")] BatchStudent batchStudent)
        {
            if (!ModelState.IsValid)
            {
                _context.Add(batchStudent);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["BatchId"] = new SelectList(_context.Batches, "BatchId", "BatchId", batchStudent.BatchId);
            ViewData["StudentId"] = new SelectList(_context.Students, "StudentId", "BillingAddress", batchStudent.StudentId);
            return View(batchStudent);
        }

        // GET: BatchStudents/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var batchStudent = await _context.BatchStudents.FindAsync(id);
            if (batchStudent == null)
            {
                return NotFound();
            }
            ViewData["BatchId"] = new SelectList(_context.Batches, "BatchId", "BatchNotes", batchStudent.BatchId);
            ViewData["StudentId"] = new SelectList(_context.Students, "StudentId", "BillingAddress", batchStudent.StudentId);
            return View(batchStudent);
        }

        // POST: BatchStudents/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("BatchStudentId,StudentId,BatchId,AmountToPay,Received")] BatchStudent batchStudent)
        {
            if (id != batchStudent.BatchStudentId)
            {
                return NotFound();
            }

            if (!ModelState.IsValid)
            {
                try
                {
                    _context.Update(batchStudent);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BatchStudentExists(batchStudent.BatchStudentId))
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
            ViewData["BatchId"] = new SelectList(_context.Batches, "BatchId", "BatchNotes", batchStudent.BatchId);
            ViewData["StudentId"] = new SelectList(_context.Students, "StudentId", "BillingAddress", batchStudent.StudentId);
            return View(batchStudent);
        }

        // GET: BatchStudents/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var batchStudent = await _context.BatchStudents
                .Include(b => b.Batches)
                .Include(b => b.Students)
                .FirstOrDefaultAsync(m => m.BatchStudentId == id);
            if (batchStudent == null)
            {
                return NotFound();
            }

            return View(batchStudent);
        }

        // POST: BatchStudents/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var batchStudent = await _context.BatchStudents.FindAsync(id);
            if (batchStudent != null)
            {
                _context.BatchStudents.Remove(batchStudent);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool BatchStudentExists(int id)
        {
            return _context.BatchStudents.Any(e => e.BatchStudentId == id);
        }
    }
}
