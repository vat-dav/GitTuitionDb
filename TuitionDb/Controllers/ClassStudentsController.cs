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
    public class ClassStudentsController : Controller
    {
        private readonly TuitionDbContext _context;

        public ClassStudentsController(TuitionDbContext context)
        {
            _context = context;
        }

        // GET: ClassStudents
        public async Task<IActionResult> Index()
        {
            var tuitionDbContext = _context.ClassStudent.Include(c => c.Classes);
            return View(await tuitionDbContext.ToListAsync());
        }

        // GET: ClassStudents/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var classStudent = await _context.ClassStudent
                .Include(c => c.Classes)
                .FirstOrDefaultAsync(m => m.ClassStudentId == id);
            if (classStudent == null)
            {
                return NotFound();
            }

            return View(classStudent);
        }

        // GET: ClassStudents/Create
        public IActionResult Create()
        {
            ViewData["ClassId"] = new SelectList(_context.Set<Class>(), "ClassId", "ClassId");
            return View();
        }

        // POST: ClassStudents/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ClassStudentId,ClassId,StudentId")] ClassStudent classStudent)
        {
            if (ModelState.IsValid)
            {
                _context.Add(classStudent);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["ClassId"] = new SelectList(_context.Set<Class>(), "ClassId", "ClassId", classStudent.ClassId);
            return View(classStudent);
        }

        // GET: ClassStudents/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var classStudent = await _context.ClassStudent.FindAsync(id);
            if (classStudent == null)
            {
                return NotFound();
            }
            ViewData["ClassId"] = new SelectList(_context.Set<Class>(), "ClassId", "ClassId", classStudent.ClassId);
            return View(classStudent);
        }

        // POST: ClassStudents/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ClassStudentId,ClassId,StudentId")] ClassStudent classStudent)
        {
            if (id != classStudent.ClassStudentId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(classStudent);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ClassStudentExists(classStudent.ClassStudentId))
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
            ViewData["ClassId"] = new SelectList(_context.Set<Class>(), "ClassId", "ClassId", classStudent.ClassId);
            return View(classStudent);
        }

        // GET: ClassStudents/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var classStudent = await _context.ClassStudent
                .Include(c => c.Classes)
                .FirstOrDefaultAsync(m => m.ClassStudentId == id);
            if (classStudent == null)
            {
                return NotFound();
            }

            return View(classStudent);
        }

        // POST: ClassStudents/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var classStudent = await _context.ClassStudent.FindAsync(id);
            if (classStudent != null)
            {
                _context.ClassStudent.Remove(classStudent);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ClassStudentExists(int id)
        {
            return _context.ClassStudent.Any(e => e.ClassStudentId == id);
        }
    }
}
