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
    public class ClassSubjectsController : Controller
    {
        private readonly TuitionDbContext _context;

        public ClassSubjectsController(TuitionDbContext context)
        {
            _context = context;
        }

        // GET: ClassSubjects
        public async Task<IActionResult> Index()
        {
            return View(await _context.ClassSubject.ToListAsync());
        }

        // GET: ClassSubjects/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var classSubject = await _context.ClassSubject
                .FirstOrDefaultAsync(m => m.SubjectId == id);
            if (classSubject == null)
            {
                return NotFound();
            }

            return View(classSubject);
        }

        // GET: ClassSubjects/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: ClassSubjects/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("SubjectId,SubjectName")] ClassSubject classSubject)
        {
            if (ModelState.IsValid)
            {
                _context.Add(classSubject);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(classSubject);
        }

        // GET: ClassSubjects/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var classSubject = await _context.ClassSubject.FindAsync(id);
            if (classSubject == null)
            {
                return NotFound();
            }
            return View(classSubject);
        }

        // POST: ClassSubjects/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("SubjectId,SubjectName")] ClassSubject classSubject)
        {
            if (id != classSubject.SubjectId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(classSubject);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ClassSubjectExists(classSubject.SubjectId))
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
            return View(classSubject);
        }

        // GET: ClassSubjects/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var classSubject = await _context.ClassSubject
                .FirstOrDefaultAsync(m => m.SubjectId == id);
            if (classSubject == null)
            {
                return NotFound();
            }

            return View(classSubject);
        }

        // POST: ClassSubjects/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var classSubject = await _context.ClassSubject.FindAsync(id);
            if (classSubject != null)
            {
                _context.ClassSubject.Remove(classSubject);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ClassSubjectExists(int id)
        {
            return _context.ClassSubject.Any(e => e.SubjectId == id);
        }
    }
}
