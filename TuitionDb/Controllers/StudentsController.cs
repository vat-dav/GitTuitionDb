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
using X.PagedList;
using Microsoft.Extensions.FileSystemGlobbing;

namespace TuitionDb.Controllers
{
    [Authorize] // this data annotation makes it so only logged in users can make changes to this controller
    public class StudentsController : Controller
    {
        private readonly TuitionDbContext _context;
        
        public StudentsController(TuitionDbContext context)
        {
            _context = context;
        }

        // GET: Students - the index method passes variables to the students index page to have sorting, filtering, and pagination.
        public async Task<IActionResult> Index(string searchStudent, string currentFilter, string searchString, int? pageNumber)
        {

           
            if (searchString != null) // if a searchstring value is given, set the page number to 1
            {
                pageNumber = 1;
            }
           
            else // else it will be set as the same as the currentFilter variable
            {
                searchString = currentFilter;
            }
            
            ViewBag.CurrentFilter = searchString;//stores currentfilter value to display in the index view


            if (_context.Students == null) // if the Students context is null, returns error
            {
                return Problem("Entity set 'TuitionDbContext.Students'  is null.");
            }

           
            var studentsSearch = from s in _context.Students
                                 select s; // selects all stored students from Students context 

            
            if (!String.IsNullOrEmpty(searchStudent))// if a search term is not null or empty, search for students that meet the criteria based off their first name
            {
                studentsSearch = studentsSearch.Where(s => s.StudentFirstName.Contains(searchStudent));


            }
            
           
            int sc = await _context.Students.CountAsync();
            @ViewBag.Sc = sc; // counts the total amount of students asynchronously in the table, and stores it in a viewbag for usage in the index view

            
            int pageSize = 10;// sets a 'page size' for pagination (the amount of records shown per page)

            
            return View(await PaginatedList<Student>.CreateAsync(studentsSearch.AsNoTracking(), pageNumber ?? 1, pageSize));// return the view with pagination and with the users search criteria without tracking changes

           

        }

        // GET: Students/Details/ - displays the details of a student record

        public async Task<IActionResult> Details(int? id)
        {
            
            if (id == null)// if the users id is null/can't be found, return Error 404, page not found
            {
                return NotFound();
            }
            
            var student = await _context.Students
                .FirstOrDefaultAsync(m => m.StudentId == id);// searches the students table and retrieves the data for a student who the user wants to view the details of

           
            if (student == null) // if a student variable is null, returns Error page 404, page not found
            {
                return NotFound();
            }

            
            return View(student);// returns the details view with passing the parameter of student
        }

        // GET: Students/Create - GETS the data that it needs to display in the create form
        public IActionResult Create()
        {
            
            return View();// returns view
        }

        // POST: Students/Create - POSTS (creates a new record) the data from the users form to the VS SQL server database
       
        [HttpPost] // data annotation for posting users input into the database
        [ValidateAntiForgeryToken] // validates the users form by assigning the user a token when they first clicked the create button, and must be sent and validated by being included in the form when submitted.
        public async Task<IActionResult> Create([Bind("StudentId,StudentFirstName,StudentLastName,StudentPhone,StudentSchool,YearLevel,Course,PaymentType,BillingAddress,JoinDate")] Student student) // binds all of the users input to a specific StudentId
        {
          
            if (ModelState.IsValid)  //checks if the model state is not valid
            {
                _context.Add(student); // adds a student to the context
                await _context.SaveChangesAsync(); // saves changes to the context, uses the await keyword to wait for other tasks to be completed first
                return RedirectToAction(nameof(Index)); //redirect to the index action of the student
            }
           
            return View(student); // returns the view with student variable
        }

        // GET: Students/Edit/5 - displays the edit form for a specific student
        public async Task<IActionResult> Edit(int? id)
        {

            if (id == null) // if the id is null, return page not found, error 404
            {
                return NotFound();
            }

            
            var student = await _context.Students.FindAsync(id);//find the student depending on the id of the student

          
            if (student == null)  // if the student value is null, return error 404, page not found
            {
                return NotFound();
            }

           
            return View(student); // returns view with respect of students records data
        }

        // POST: Students/Edit/5 - handles the form being submitted for editing a specific student record

        [HttpPost] // data annotation for posting users input into the database
        [ValidateAntiForgeryToken] // validates the users form by assigning the user a token when they first clicked the create button, and must be sent and validated by being included in the form when submitted.
        public async Task<IActionResult> Edit(int id, [Bind("StudentId,StudentFirstName,StudentLastName,StudentPhone,StudentSchool,YearLevel,Course,PaymentType,BillingAddress,JoinDate")] Student student) // binds all of the users input to a specific StudentId
        {
         
            if (id != student.StudentId)// if the id is not matching the student records studentId, return page not found error 404
            {
                return NotFound();
            }

            if (ModelState.IsValid)    // if the model state is not valid
            {
                try
                {
                    
                    _context.Update(student); //try update the student record
                   
                    await _context.SaveChangesAsync();  // asynchronously save the changes to the database
                }

                catch (DbUpdateConcurrencyException)
                {
                    if (!StudentExists(student.StudentId)) // if the student doesnt exist with respect to the student records studentId, return page not found error 404
                    {
                        return NotFound(); 
                    }
                    else
                    {
                        throw; // rethrow the exception if its not due to the following issues
                    }
                }
                return RedirectToAction(nameof(Index)); // redirect the index action
            }
            
            return View(student); // returns the view with the student records data
        }

        // GET: Students/Delete/5 - displays the delete view for a specific student
        public async Task<IActionResult> Delete(int? id)
        {
        
            if (id == null)    // if the id is null, it returns the error 404 page not found
            {
                return NotFound();
            }

           
            var student = await _context.Students
                .FirstOrDefaultAsync(m => m.StudentId == id); // searches the students table and retrieves the data for a student who the user wants to view the details of when user wants to delete

          
            if (student == null)  // if the student variable is null, it returns the error 404 page not found
            {
                return NotFound();
            }

           
            return View(student); // returns the view with respect to the student records
        }

        // POST: Students/Delete/5 - this method handles the form which needs to be submitted when deleting a student
        
        [HttpPost, ActionName("Delete")] // data annotation for posting users input into the database, and ensures the action name is Delete and not DeleteConfirmed
       
        [ValidateAntiForgeryToken]// validates the users form by assigning the user a token when they first clicked the create button, and must be sent and validated by being included in the form when submitted.
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            
            var student = await _context.Students.FindAsync(id);// find the student depending on the studentId

            
            if (student != null)// if the student record is not null, it removes the student record from the database
            {
                _context.Students.Remove(student);
            }

          
            await _context.SaveChangesAsync();  //asynchronously saves the 'new' context after the removing of the record

            
            return RedirectToAction(nameof(Index));// returns the index action of the controller
        }
        
        private bool StudentExists(int id)// checks if a student exists depending on their Id,then returns true if record exists, and false if record doesnt exist
        {
            return _context.Students.Any(e => e.StudentId == id);
        }
    }
}