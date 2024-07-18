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
using TuitionDbv1;
using TuitionDbv1.Models;

namespace TuitionDb.Controllers
{
    [Authorize] // this data annotation makes it so only logged in users can make changes to this controller
    public class StaffsController : Controller
    {
        private readonly TuitionDbContext _context;


        public StaffsController(TuitionDbContext context)
        {
            _context = context;
        }

        // GET: Staffs - the index method passes variables to the staffs index page to have sorting, filtering, and pagination
        public async Task<IActionResult> Index(string searchStaff, string currentFilter, string searchString, int? pageNumber)
        {


            if (searchString != null) // if a search string value is given, set the page number to 1
            {
                pageNumber = 1;

            }
            else // else it will be set as the same as the currentFilter variable
            {

                searchString = currentFilter;
            }

            ViewBag.CurrentFilter = searchString; // stores currentFilter value to display in the index view


            if (_context.Staffs == null) // if the staffs table is null, return a problem message
            {
                return Problem("Entity set 'TuitionDbContext.Staffs'  is null.");
            }


            var staffsSearch = from s in _context.Staffs select s; // selects all stored staffs from Staffs table 


            if (!String.IsNullOrEmpty(searchStaff)) // if a search staff value is given, filter staffs by first name or last name
            {
                staffsSearch = staffsSearch.Where(s => s.StaffFirstName.Contains(searchStaff) || s.StaffLastName.Contains(searchStaff));
            }

            int sc = await _context.Staffs.CountAsync(); // gets the count of all staffs asynchronously
            @ViewBag.Sc = sc; // stores the count of staffs in ViewBag


            int pageSize = 10; // sets the page size for pagination


            return View(await PaginatedList<Staff>.CreateAsync(staffsSearch.AsNoTracking(), pageNumber ?? 1, pageSize)); // returns the view with paginated staffs
        }

        // GET: Staffs/Details/5 - displays the details of a staff record
        public async Task<IActionResult> Details(int? id)

        {
            if (id == null) // if the id is null, return Error 404, page not found

            {
                return NotFound();
            }

            var staff = await _context.Staffs
                .FirstOrDefaultAsync(m => m.StaffId == id); // searches the staffs table and retrieves the data for a staff


            if (staff == null) // if a staff variable is null, returns Error page 404, page not found
            {
                return NotFound();
            }

            return View(staff); // returns the details view with the staff variable
        }

        // GET: Staffs/Create - gets the data that it needs to display in the create form
        public IActionResult Create()
        {
            return View(); // returns view
        }

        // POST: Staffs/Create - posts (creates a new record) the data from the users form to the VS SQL server database

        [HttpPost] // data annotation for posting users input into the database

        [ValidateAntiForgeryToken] // validates the users form by assigning the user a token when they first clicked the create button, and must be sent and validated by being included in the form when submitted


        public async Task<IActionResult> Create([Bind("StaffId,StaffFirstName,StaffLastName,StaffEmail,StaffPhone,Positions")] Staff staff) // binds all of the users input to a specific StaffId

        {
            if (ModelState.IsValid) // checks if the model state is valid
            {
                _context.Add(staff); // adds a staff to the database
                await _context.SaveChangesAsync(); // saves changes to the database, uses the await keyword to wait for other tasks to be completed first
                return RedirectToAction(nameof(Index)); // redirects to the index action of the staff
            }


            return View(staff); // returns the view with staff variable
        }

        // GET: Staffs/Edit/5 - displays the edit form for a specific staff
        public async Task<IActionResult> Edit(int? id)

        {
            if (id == null) // if the id is null, return Error 404, page not found
            {
                return NotFound();
            }

            var staff = await _context.Staffs.FindAsync(id); // finds the staff depending on the id of the staff


            if (staff == null) // if the staff value is null, return error 404, page not found
            {
                return NotFound();
            }

            return View(staff); // returns view with respect to staff records data
        }

        // POST: Staffs/Edit/5 - handles the form being submitted for editing a specific staff record

        [HttpPost] // data annotation for posting users input into the database

        [ValidateAntiForgeryToken] // validates the users form by assigning the user a token when they first clicked the create button, and must be sent and validated by being included in the form when submitted
        public async Task<IActionResult> Edit(int id, [Bind("StaffId,StaffFirstName,StaffLastName,StaffEmail,StaffPhone,Positions")] Staff staff) // binds all of the users input to a specific StaffId

        {
            if (id != staff.StaffId) // if the id is not matching the staff records StaffId, return Error 404, page not found
            {
                return NotFound();
            }


            if (ModelState.IsValid) // if the model state is valid
            {

                try
                {
                    _context.Update(staff); // tries to update the staff record
                    await _context.SaveChangesAsync(); // asynchronously saves the changes to the database
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!StaffExists(staff.StaffId)) // if the staff doesn't exist with respect to the staff records StaffId, return Error 404, page not found
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw; // rethrows the exception if it's not due to the following issues
                    }
                }
                return RedirectToAction(nameof(Index)); // redirects to the index action
            }
            return View(staff); // returns the view with the staff records data
        }

        // GET: Staffs/Delete/5 - displays the delete view for a specific staff
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null) // if the id is null, return Error 404, page not found

            {
                return NotFound();
            }

            var staff = await _context.Staffs
                .FirstOrDefaultAsync(m => m.StaffId == id); // finds the staff record with respect to StaffId

            if (staff == null) // if the staff value is null, return error 404, page not found
            {
                return NotFound();
            }

            return View(staff); // returns view with staff records data
        }

        // POST: Staffs/Delete/5 - handles the form submission for deleting a specific staff record

        [HttpPost, ActionName("Delete")] // data annotation for posting users input into the database

        [ValidateAntiForgeryToken] // validates the users form by assigning the user a token when they first clicked the create button, and must be sent and validated by being included in the form when submitted
        public async Task<IActionResult> DeleteConfirmed(int id) // binds the id parameter to delete the staff record
        {
            var staff = await _context.Staffs.FindAsync(id); // finds the staff record with respect to StaffId
            if (staff != null) // if the staff record is not null
            {
                _context.Staffs.Remove(staff); // removes the staff record from the database
            }

            await _context.SaveChangesAsync(); // asynchronously saves the changes to the database
            return RedirectToAction(nameof(Index)); // redirects to the index action
        }

        private bool StaffExists(int id) // checks if the staff exists depending on their id, then returns true if record exists, and false if record doesnt exist
        {
            return _context.Staffs.Any(e => e.StaffId == id);
        }
    }
}
