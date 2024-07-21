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

namespace TuitionDb.Controllers
{
    [Authorize] // this data annotation makes it so only logged in users can make changes to this controller
    public class SubjectsController : Controller
    {
        private readonly TuitionDbContext _context;

        public SubjectsController(TuitionDbContext context)
        {
            _context = context;
        }

        // GET: Subjects - the index method retrieves and displays a list of subjects
        public async Task<IActionResult> Index(string searchSubject)
        {
            if (_context.Subjects == null) // if the subjects context is null, return a problem message
            {
                return Problem("Entity set 'TuitionDbContext.Subjects'  is null.");
            }

            var subjectsSearch = from s in _context.Subjects
                                 select s; // selects all subjects from the database

            if (!String.IsNullOrEmpty(searchSubject)) // if a search string is provided, filter subjects by subject name
            {
                subjectsSearch = subjectsSearch.Where(s => s.SubjectName!.Contains(searchSubject));
            }


            return View(await subjectsSearch.ToListAsync()); // returns the view with the filtered list of subjects
        }

        // GET: Subjects/Details/5 - displays the details of a specific subject
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null) // if the id is null, return Error 404, page not found
            {
                return NotFound();
            }

            var subject = await _context.Subjects
                .FirstOrDefaultAsync(m => m.SubjectId == id); // finds the subject by id
            if (subject == null) // if the subject is null, return Error 404, page not found
            {
                return NotFound();
            }

            return View(subject); // returns the details view with the subject data
        }

        // GET: Subjects/Create - displays the create form for a new subject
        public IActionResult Create()
        {
            return View(); // returns the create view
        }

        // POST: Subjects/Create - handles the form submission for creating a new subject
        [HttpPost] // data annotation for posting users input into the database
        [ValidateAntiForgeryToken] // validates the users form by assigning a token that must be included when the form is submitted
        public async Task<IActionResult> Create([Bind("SubjectId,SubjectName")] Subject subject) // binds the form input to the subject model
        {
            if (!ModelState.IsValid) // if the model state is not valid
            {
                _context.Add(subject); // adds the subject to the database
                await _context.SaveChangesAsync(); // asynchronously saves changes to the database
                return RedirectToAction(nameof(Index)); // redirects to the index action
            }
            return View(subject); // returns the create view with the subject data
        }

        // GET: Subjects/Edit/5 - displays the edit form for a specific subject
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null) // if the id is null, return Error 404, page not found
            {
                return NotFound();
            }

            var subject = await _context.Subjects.FindAsync(id); // finds the subject by id
            if (subject == null) // if the subject is null, return Error 404, page not found
            {
                return NotFound();

            }
            return View(subject); // returns the edit view with the subject data
        }

        // POST: Subjects/Edit/5 - handles the form submission for editing a specific subject
        [HttpPost] // data annotation for posting users input into the database
        [ValidateAntiForgeryToken] // validates the users form by assigning a token that must be included when the form is submitted
        public async Task<IActionResult> Edit(int id, [Bind("SubjectId,SubjectName")] Subject subject) // binds the form input to the subject model
        {
            if (id != subject.SubjectId) // if the id does not match the subject id, return Error 404, page not found
            {
                return NotFound();
            }

            if (!ModelState.IsValid) // if the model state is not valid
            {
                try
                {
                    _context.Update(subject); // tries to update the subject in the database

                    await _context.SaveChangesAsync(); // asynchronously saves changes to the database
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SubjectExists(subject.SubjectId)) // if the subject does not exist, return Error 404, page not found
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw; // rethrows the exception if it's not due to concurrency issues
                    }
                }
                return RedirectToAction(nameof(Index)); // redirects to the index action
            }
            return View(subject); // returns the edit view with the subject data
        }

        // GET: Subjects/Delete/5 - displays the delete view for a specific subject
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null) // if the id is null, return Error 404, page not found
            {
                return NotFound();
            }

            var subject = await _context.Subjects
                .FirstOrDefaultAsync(m => m.SubjectId == id); // finds the subject by id
            if (subject == null) // if the subject is null, return Error 404, page not found
            {
                return NotFound();
            }

            return View(subject); // returns the delete view with the subject data
        }

        // POST: Subjects/Delete/5 - handles the form submission for deleting a specific subject

        [HttpPost, ActionName("Delete")] // data annotation for posting users input into the database

        [ValidateAntiForgeryToken] // validates the users form by assigning a token that must be included when the form is submitted
        public async Task<IActionResult> DeleteConfirmed(int id) // confirms the deletion of the subject
        {
            var subject = await _context.Subjects.FindAsync(id); // finds the subject by its id
            if (subject != null)

            {
                _context.Subjects.Remove(subject); // removes the subject from the database
            }

            await _context.SaveChangesAsync(); // asynchronously saves changes to the database
            return RedirectToAction(nameof(Index)); // redirects to the index action
        }

        private bool SubjectExists(int id) // checks if a subject exists by id, then returns true if record exists, and false if record doesnt exist
        {
            return _context.Subjects.Any(e => e.SubjectId == id);
        }
    }
}
