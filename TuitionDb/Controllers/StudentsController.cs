using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using NuGet.Protocol.Plugins;
using TuitionDb.Areas.Identity.Data;
using TuitionDbv1;
using TuitionDbv1.Models;
using PagedList;
using Microsoft.Extensions.FileSystemGlobbing;

namespace TuitionDb.Controllers
{
    [Authorize]
    public class StudentsController : Controller
    {
        private readonly TuitionDbContext _context;

        public StudentsController(TuitionDbContext context)
        {
            _context = context;
        }

        // GET: Students
        public async Task<IActionResult> Index(string searchStudent, string sortOrder, string currentFilter, string searchString, int? page)
        {
            ViewBag.CurrentSort = sortOrder;

            if (searchString != null)
            {
                page = 1;
            }
            else
            {
                searchString = currentFilter;
            }

            ViewBag.CurrentFilter = searchString;

            if (_context.Students == null)
            {
                return Problem("Entity set 'TuitionDbContext.Students'  is null.");
            }

            var studentsSearch = from s in _context.Students
                                 select s;

            if (!String.IsNullOrEmpty(searchStudent))
            {
                studentsSearch = studentsSearch.Where(s => s.StudentFirstName!.Contains(searchStudent))
                                                .Concat(studentsSearch.Where(s => s.StudentLastName!.Contains(searchStudent)));
            }

            ViewBag.NameSortParm = String.IsNullOrEmpty(sortOrder) ? "name_desc" : "";
            ViewBag.DateSortParm = sortOrder == "StudentSchool" ? "date_desc" : "StudentSchool";
         
            switch (sortOrder)
            {
                case "name_desc":
                    studentsSearch = studentsSearch.OrderBy(s => s.StudentSchool);
                    break;
                case "Date":
                    studentsSearch = studentsSearch.OrderBy(s => s.YearLevel);
                    break;
                case "date_desc":
                    studentsSearch = studentsSearch.OrderBy(s => s.StudentSchool);
                    break;
                default:
                    studentsSearch = studentsSearch.OrderBy(s => s.YearLevel);
                    break;
            }

            int sc = await _context.Students.CountAsync();
            @ViewBag.Sc = sc;

          
  
            return View(await studentsSearch.AsNoTracking().ToListAsync());
           

        }

        // GET: Students/Details/
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var student = await _context.Students
                .FirstOrDefaultAsync(m => m.StudentId == id);
            if (student == null)
            {
                return NotFound();
            }

            return View(student);
        }

        // GET: Students/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Students/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("StudentId,StudentFirstName,StudentLastName,StudentPhone,StudentSchool,YearLevel,Course,BatchDay,BatchTime,PaymentType,BillingAddress,JoinDate")] Student student)
        {
            if (ModelState.IsValid)
            {
                _context.Add(student);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(student);
        }

        // GET: Students/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var student = await _context.Students.FindAsync(id);
            if (student == null)
            {
                return NotFound();
            }
            return View(student);
        }

        // POST: Students/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("StudentId,StudentFirstName,StudentLastName,StudentPhone,StudentSchool,YearLevel,Course,BatchDay,BatchTime,PaymentType,BillingAddress,JoinDate")] Student student)
        {
            if (id != student.StudentId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(student);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!StudentExists(student.StudentId))
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
            return View(student);
        }

        // GET: Students/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var student = await _context.Students
                .FirstOrDefaultAsync(m => m.StudentId == id);
            if (student == null)
            {
                return NotFound();
            }

            return View(student);
        }

        // POST: Students/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var student = await _context.Students.FindAsync(id);
            if (student != null)
            {
                _context.Students.Remove(student);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool StudentExists(int id)
        {
            return _context.Students.Any(e => e.StudentId == id);
        }
    }
}