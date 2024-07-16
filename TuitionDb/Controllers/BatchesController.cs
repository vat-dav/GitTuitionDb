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
    [Authorize] // this data annotation makes it so only logged in users can make changes to this controller
    public class BatchesController : Controller
    {
        private readonly TuitionDbContext _context;

        public BatchesController(TuitionDbContext context)
        {
            _context = context;
        }

        // GET: Batches - the index method passes variables to the batches index page to have sorting, filtering, and pagination.
        public async Task<IActionResult> Index(string sortOrder, string currentFilter, string searchString, int? pageNumber)
        {
            ViewData["CurrentSort"] = sortOrder; // stores the current sort order to display in the index view

            if (searchString != null) // if a search string value is given, set the page number to 1
            {
                pageNumber = 1;
            }
            else // else it will be set as the same as the currentFilter variable
            {
                searchString = currentFilter;
            }

            ViewBag.CurrentFilter = searchString; // stores currentFilter value to display in the index view

            var batches = from b in _context.Batches
                          select b; // selects all stored batches from Batches context 

            // sets sorting parameters for sorting
            ViewBag.NameSortParm = String.IsNullOrEmpty(sortOrder) ? "name_desc" : "";
            ViewBag.DateSortParm = sortOrder == "date" ? "date_desc" : "date";

            switch (sortOrder)
            {
                case "name_desc":
                    batches = batches.OrderByDescending(b => b.BatchDay); // sorts batches by batch day in descending order
                    break;
                case "date":
                    batches = batches.OrderBy(b => b.BatchTime); // sorts batches by batch time in ascending order
                    break;
                case "date_desc":
                    batches = batches.OrderByDescending(b => b.BatchTime); // sorts batches by batch time in descending order
                    break;
                default:
                    batches = batches.OrderBy(b => b.BatchDay); // default sort by batch day in ascending order
                    break;
            }

            var sortedBatches = await batches
                .Include(b => b.Staffs)
                .Include(b => b.Subjects)
                .Include(b => b.BatchStudents)
                .ThenInclude(bs => bs.Students)
                .AsNoTracking()
                .ToListAsync(); // includes related data and gets a list asynchronously without tracking changes

            return View(sortedBatches); // returns the view with sorted batches
        }

        // GET: Batches/Details/5 - displays the details of a batch record
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null) // if the id is null, return Error 404, page not found
            {
                return NotFound();
            }

            var batch = await _context.Batches
                .Include(b => b.Staffs)
                .Include(b => b.Subjects)
                .Include(b => b.BatchStudents)
                .ThenInclude(bs => bs.Students)
                .FirstOrDefaultAsync(m => m.BatchId == id); // searches the batches table and retrieves the data for a batch

            if (batch == null) // if a batch variable is null, returns Error page 404, page not found
            {
                return NotFound();
            }

            var viewModel = new ViewBatchStudents
            {
                Batches = batch,
                Students = batch.BatchStudents.Select(bs => bs.Students).ToList() // creates a view model for users who click batch details, it will display what students in a batch
            };

            return View(viewModel); // returns the details view with passing the parameter of viewModel
        }

        // GET: Batches/Create - GETS the data that it needs to display in the create form
        public IActionResult Create()
        {
            var staffTeachers = _context.Staffs.Where(s => s.Positions == Staff.StaffPosition.Teacher).ToList(); // gets a list of teachers
            ViewBag.Teachers = new SelectList(staffTeachers, "StaffId", "FullName"); // passes teachers to viewbag
            ViewBag.SubjectId = new SelectList(_context.Subjects, "SubjectId", "SubjectName"); // passes subjects to viewbag

            return View(); // returns view
        }

        // POST: Batches/Create - POSTS (creates a new record) the data from the users form to the VS SQL server database
        [HttpPost] // data annotation for posting users input into the database
        [ValidateAntiForgeryToken] // validates the users form by assigning the user a token when they first clicked the create button, and must be sent and validated by being included in the form when submitted.
        public async Task<IActionResult> Create([Bind("BatchId,BatchDay,BatchTime,StaffId,SubjectId")] Batch batch) // binds all of the users input to a specific BatchId
        {
            if (ModelState.IsValid) // checks if the model state is valid
            {
                _context.Add(batch); // adds a batch to the context
                await _context.SaveChangesAsync(); // saves changes to the context, uses the await keyword to wait for other tasks to be completed first
                return RedirectToAction(nameof(Index)); // redirects to the index action of the batch
            }
            ViewData["StaffId"] = new SelectList(_context.Staffs, "StaffId", "StaffName", batch.StaffId); // sets staff id for viewdata
            ViewBag.SubjectId = new SelectList(_context.Subjects, "SubjectId", "SubjectName", batch.SubjectId); // sets subject id for viewbag

            return View(batch); // returns the view with batch variable
        }

        // GET: Batches/Edit/5 - displays the edit form for a specific batch
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null) // if the id is null, return Error 404, page not found
            {
                return NotFound();
            }

            var batch = await _context.Batches.FindAsync(id); // finds the batch depending on the id of the batch

            if (batch == null) // if the batch value is null, return error 404, page not found
            {
                return NotFound();
            }

            var staffTeachers = _context.Staffs.Where(s => s.Positions == Staff.StaffPosition.Teacher).ToList(); // gets a list of teachers
            ViewBag.Teachers = new SelectList(staffTeachers, "StaffId", "FullName"); // passes teachers to viewbag
            ViewBag.SubjectId = new SelectList(_context.Subjects, "SubjectId", "SubjectName"); // passes subjects to viewbag

            return View(batch); // returns view with respect to batch records data
        }

        // POST: Batches/Edit/5 - handles the form being submitted for editing a specific batch record
        [HttpPost] // data annotation for posting users input into the database
        [ValidateAntiForgeryToken] // validates the users form by assigning the user a token when they first clicked the create button, and must be sent and validated by being included in the form when submitted.
        public async Task<IActionResult> Edit(int id, [Bind("BatchId,BatchDay,BatchTime,SubjectId,StaffId")] Batch batch) // binds all of the users input to a specific BatchId
        {
            if (id != batch.BatchId) // if the id is not matching the batch records BatchId, return Error 404, page not found
            {
                return NotFound();
            }

            var staffTeachers = _context.Staffs.Where(s => s.Positions == Staff.StaffPosition.Teacher).ToList(); // gets a list of teachers
            ViewBag.Teachers = new SelectList(staffTeachers, "StaffId", "FullName", batch.StaffId); // passes teachers to viewbag
            ViewBag.SubjectId = new SelectList(_context.Subjects, "SubjectId", "SubjectName", batch.SubjectId); // passes subjects to viewbag

            if (ModelState.IsValid) // if the model state is valid
            {
                try
                {
                    _context.Update(batch); // tries to update the batch record
                    await _context.SaveChangesAsync(); // asynchronously saves the changes to the database
                    return RedirectToAction(nameof(Index)); // redirects to the index action
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BatchExists(batch.BatchId)) // if the batch doesn't exist with respect to the batch records BatchId, return Error 404, page not found
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw; // rethrows the exception if it's not due to the following issues
                    }
                }
            }
            return View(batch); // returns the view with the batch records data
        }

        // GET: Batches/Delete/5 - displays the delete view for a specific batch
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null) // if the id is null, return Error 404, page not found
            {
                return NotFound();
            }

            var batch = await _context.Batches
                .Include(b => b.Staffs)
                .Include(b => b.Subjects)
                .FirstOrDefaultAsync(m => m.BatchId == id); // finds the batch record with respect to BatchId

            if (batch == null) // if the batch value is null, return error 404, page not found
            {
                return NotFound();
            }

            return View(batch); // returns view with batch records data
        }

        // POST: Batches/Delete/5 - handles the form submission for deleting a specific batch record
        [HttpPost, ActionName("Delete")] // data annotation for posting users input into the database
        [ValidateAntiForgeryToken] // validates the users form by assigning the user a token when they first clicked the create button, and must be sent and validated by being included in the form when submitted.
        public async Task<IActionResult> DeleteConfirmed(int id) // binds the id parameter to delete the batch record
        {
            var batch = await _context.Batches.FindAsync(id); // finds the batch record with respect to BatchId
            _context.Batches.Remove(batch); // removes the batch record from the context
            await _context.SaveChangesAsync(); // asynchronously saves the changes to the database
            return RedirectToAction(nameof(Index)); // redirects to the index action
        }

        private bool BatchExists(int id) //  checks if the batch exists depending on their id, then returns true if record exists, and false if record doesnt exist
        {
            return _context.Batches.Any(e => e.BatchId == id);
        }
    }
}
