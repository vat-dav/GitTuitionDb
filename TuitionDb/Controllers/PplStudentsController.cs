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
    public class PplStudentsController : Controller
    {
        private readonly TuitionDbContext _context;

        public PplStudentsController(TuitionDbContext context)
        {
            _context = context;
        }

        // GET: PplStudents
        public async Task<IActionResult> Index()
        {
            return View(await _context.PplStudent.ToListAsync());
        }

        // GET: PplStudents/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pplStudent = await _context.PplStudent
                .FirstOrDefaultAsync(m => m.StudentId == id);
            if (pplStudent == null)
            {
                return NotFound();
            }

            return View(pplStudent);
        }

        // GET: PplStudents/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: PplStudents/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("StudentId,StudentName,StudentLastName,StudentPhone,StudentSchool,BatchTime,BatchDay,YearLevel,Course,JoinDate,ParentID,StaffId")] PplStudent pplStudent)
        {
            if (ModelState.IsValid)
            {
                _context.Add(pplStudent);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(pplStudent);
        }

        // GET: PplStudents/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pplStudent = await _context.PplStudent.FindAsync(id);
            if (pplStudent == null)
            {
                return NotFound();
            }
            return View(pplStudent);
        }

        // POST: PplStudents/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("StudentId,StudentName,StudentLastName,StudentPhone,StudentSchool,BatchTime,BatchDay,YearLevel,Course,JoinDate,ParentID,StaffId")] PplStudent pplStudent)
        {
            if (id != pplStudent.StudentId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(pplStudent);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PplStudentExists(pplStudent.StudentId))
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
            return View(pplStudent);
        }

        // GET: PplStudents/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pplStudent = await _context.PplStudent
                .FirstOrDefaultAsync(m => m.StudentId == id);
            if (pplStudent == null)
            {
                return NotFound();
            }

            return View(pplStudent);
        }

        // POST: PplStudents/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var pplStudent = await _context.PplStudent.FindAsync(id);
            if (pplStudent != null)
            {
                _context.PplStudent.Remove(pplStudent);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PplStudentExists(int id)
        {
            return _context.PplStudent.Any(e => e.StudentId == id);
        }
    }
}
