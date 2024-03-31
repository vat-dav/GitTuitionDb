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
    public class PplStaffsController : Controller
    {
        private readonly TuitionDbContext _context;

        public PplStaffsController(TuitionDbContext context)
        {
            _context = context;
        }

        // GET: PplStaffs
        public async Task<IActionResult> Index()
        {
            return View(await _context.PplStaff.ToListAsync());
        }

        // GET: PplStaffs/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pplStaff = await _context.PplStaff
                .FirstOrDefaultAsync(m => m.StaffId == id);
            if (pplStaff == null)
            {
                return NotFound();
            }

            return View(pplStaff);
        }

        // GET: PplStaffs/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: PplStaffs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("StaffId,StaffName,Staff,StaffPhone")] PplStaff pplStaff)
        {
            if (ModelState.IsValid)
            {
                _context.Add(pplStaff);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(pplStaff);
        }

        // GET: PplStaffs/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pplStaff = await _context.PplStaff.FindAsync(id);
            if (pplStaff == null)
            {
                return NotFound();
            }
            return View(pplStaff);
        }

        // POST: PplStaffs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("StaffId,StaffName,Staff,StaffPhone")] PplStaff pplStaff)
        {
            if (id != pplStaff.StaffId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(pplStaff);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PplStaffExists(pplStaff.StaffId))
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
            return View(pplStaff);
        }

        // GET: PplStaffs/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pplStaff = await _context.PplStaff
                .FirstOrDefaultAsync(m => m.StaffId == id);
            if (pplStaff == null)
            {
                return NotFound();
            }

            return View(pplStaff);
        }

        // POST: PplStaffs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var pplStaff = await _context.PplStaff.FindAsync(id);
            if (pplStaff != null)
            {
                _context.PplStaff.Remove(pplStaff);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PplStaffExists(int id)
        {
            return _context.PplStaff.Any(e => e.StaffId == id);
        }
    }
}
