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
    public class PplParentsController : Controller
    {
        private readonly TuitionDbContext _context;

        public PplParentsController(TuitionDbContext context)
        {
            _context = context;
        }

        // GET: PplParents
        public async Task<IActionResult> Index()
        {
            return View(await _context.PplParent.ToListAsync());
        }

        // GET: PplParents/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pplParent = await _context.PplParent
                .FirstOrDefaultAsync(m => m.ParentId == id);
            if (pplParent == null)
            {
                return NotFound();
            }

            return View(pplParent);
        }

        // GET: PplParents/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: PplParents/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ParentId,ParentName,ParentAddress,ParentPhone")] PplParent pplParent)
        {
            if (ModelState.IsValid)
            {
                _context.Add(pplParent);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(pplParent);
        }

        // GET: PplParents/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pplParent = await _context.PplParent.FindAsync(id);
            if (pplParent == null)
            {
                return NotFound();
            }
            return View(pplParent);
        }

        // POST: PplParents/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ParentId,ParentName,ParentAddress,ParentPhone")] PplParent pplParent)
        {
            if (id != pplParent.ParentId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(pplParent);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PplParentExists(pplParent.ParentId))
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
            return View(pplParent);
        }

        // GET: PplParents/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pplParent = await _context.PplParent
                .FirstOrDefaultAsync(m => m.ParentId == id);
            if (pplParent == null)
            {
                return NotFound();
            }

            return View(pplParent);
        }

        // POST: PplParents/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var pplParent = await _context.PplParent.FindAsync(id);
            if (pplParent != null)
            {
                _context.PplParent.Remove(pplParent);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PplParentExists(int id)
        {
            return _context.PplParent.Any(e => e.ParentId == id);
        }
    }
}
