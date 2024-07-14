using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using TuitionDb.Areas.Identity.Data;
using TuitionDbv1.Models;
using TuitionDbv1.ViewModels;


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

        // GET: Batches
        public async Task<IActionResult> Index(string sortOrder, string currentFilter, string searchString, int? pageNumber)
        {

            ViewData["CurrentSort"] = sortOrder;


            if (searchString != null)
            {
                pageNumber = 1;
            }
            else
            {
                searchString = currentFilter;
            }

            ViewBag.CurrentFilter = searchString;

            var batches = from b in _context.Batches
                          select b;

       
            ViewBag.NameSortParm = String.IsNullOrEmpty(sortOrder) ? "name_desc" : "";
            ViewBag.DateSortParm = String.IsNullOrEmpty(sortOrder) ? "date" : "date_desc";

            switch (sortOrder)
            {
                case "name_desc":
                    batches = batches.OrderByDescending(b => b.BatchDay);
                    break;
                case "date":
                    batches = batches.OrderBy(b => b.BatchTime);
                    break;
                case "date_desc":
                    batches = batches.OrderByDescending(b => b.BatchTime);
                    break;
                default:
                    batches = batches.OrderBy(b => b.BatchDay);
                    break;
                
            }
           
          

            var sortedBatches = await batches
                .Include(b => b.Staffs)
                .Include(b => b.Subjects)
                .Include(b => b.BatchStudents)
                .ThenInclude(bs => bs.Students)
                .AsNoTracking()
                .ToListAsync();

            return View(sortedBatches);
        }



        // GET: Batches/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var batch = await _context.Batches
                .Include(b => b.Staffs)
                .Include(b => b.Subjects)
                .Include(b => b.BatchStudents)
                .ThenInclude(bs => bs.Students)
                .FirstOrDefaultAsync(m => m.BatchId == id);

            if (batch == null)
            {
                return NotFound();
            }

            var viewModel = new ViewBatchStudents
            {
                Batches = batch,
                Students = batch.BatchStudents.Select(bs => bs.Students).ToList()
            };


            return View(viewModel);

        }




        // GET: Batches/Create

        public IActionResult Create()
        {
            var staffTeachers = _context.Staffs.Where(s => s.Positions == Staff.StaffPosition.Teacher).ToList();
            ViewBag.Teachers = new SelectList(staffTeachers, "StaffId", "FullName");
            ViewBag.SubjectId = new SelectList(_context.Subjects, "SubjectId", "SubjectName");

            return View();
        }

        // POST: Batches/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("BatchId,BatchDay,BatchTime,StaffId,SubjectId")] Batch batch)
        {
            if (!ModelState.IsValid)
            {
                _context.Add(batch);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["StaffId"] = new SelectList(_context.Staffs, "StaffId", "StaffName", batch.StaffId);
            ViewBag.SubjectId = new SelectList(_context.Subjects, "SubjectId", "SubjectName", batch.SubjectId);

            return View(batch);
        }

        // GET: Batches/Edit/5
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


            var staffTeachers = _context.Staffs.Where(s => s.Positions == Staff.StaffPosition.Teacher).ToList();
            ViewBag.Teachers = new SelectList(staffTeachers, "StaffId", "FullName");
            ViewBag.SubjectId = new SelectList(_context.Subjects, "SubjectId", "SubjectName");

            return View(batch);
        }

        // POST: Batches/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("BatchId,BatchDay,BatchTime,SubjectId,StaffId")] Batch batch)
        {
            if (id != batch.BatchId)
            {
                return NotFound();
            }

            var staffTeachers = _context.Staffs.Where(s => s.Positions == Staff.StaffPosition.Teacher).ToList();
            ViewBag.Teachers = new SelectList(staffTeachers, "StaffId", "FullName", batch.StaffId);
            ViewBag.SubjectId = new SelectList(_context.Subjects, "SubjectId", "SubjectName", batch.SubjectId);

            if (!ModelState.IsValid)
            {
                try
                {
                    _context.Update(batch);
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
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
            }
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
                .Include(v => v.Subjects)
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



