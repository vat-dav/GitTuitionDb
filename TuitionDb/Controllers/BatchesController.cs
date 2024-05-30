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
        public async Task<IActionResult> Index(string sortOrder)
        {
            var tuitionDbContext = _context.Batches.Include(b => b.Staffs)
             .Include(v => v.Subjects);

            int batchtoday = await _context.Batches.CountAsync();

            ViewBag.NameSortParm = String.IsNullOrEmpty(sortOrder) ? "name_desc" : "";
            ViewBag.DateSortParm = sortOrder == "Date" ? "date_desc" : "Date";
            
            var batches = from b in _context.Batches
                          select b;

            switch (sortOrder)
            {
                case "name_desc":
                    batches = batches.OrderBy(b => b.BatchDay);
                    break;
                case "Date":
                    batches = batches.OrderBy(b => b.BatchTime);
                    break;
                case "date_desc":
                    batches = batches.OrderBy(b => b.BatchDay);
                    break;
                default:
                    batches = batches.OrderBy(b => b.BatchTime);
                    break;
            }

            var data = batches.Include(b => b.Staffs)
             .Include(v => v.Subjects);

            return View(await data.AsNoTracking().ToListAsync());



        }

        // GET: Batches/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            {
                var batch = await _context.Batches
                    .Include(b => b.BatchStudents)
                   // .ThenInclude(bs => bs.Student)
                    .FirstOrDefaultAsync(m => m.BatchId == id);

                if (batch == null)
                {
                    return NotFound();
                }

                var viewModel = new ViewBatchStudents
                {
                    Batches = batch,
                    Students = batch.BatchStudents.Select(bs => bs.Student).ToList()
                };

                return View(viewModel);
            }




        }

        // GET: Batches/Create
        public IActionResult Create()
        {
            ViewData["StaffId"] = new SelectList(_context.Staffs, "StaffId", "StaffName");
            ViewBag.SubjectId = new SelectList(_context.Subjects, "SubjectId", "SubjectName");


            return View();
        }

        // POST: Batches/Create
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
            ViewData["StaffId"] = new SelectList(_context.Staffs, "StaffId", "StaffName", batch.StaffId);
            ViewBag.SubjectId = new SelectList(_context.Subjects, "SubjectId", "SubjectName");
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
            ViewData["StaffId"] = new SelectList(_context.Staffs, "StaffId", "StaffName", batch.StaffId);
            ViewBag.SubjectId = new SelectList(_context.Subjects, "SubjectId", "SubjectName");
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
            ViewData["StaffId"] = new SelectList(_context.Staffs, "StaffId", "StaffName", batch.StaffId);
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



