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

namespace TuitionDbv1.Controllers
{
    [Authorize] // this data annotation makes it so only logged in users can make changes to this controller
    public class BatchStudentsController : Controller
    {
        private readonly TuitionDbContext _context;

        public BatchStudentsController(TuitionDbContext context)
        {
            _context = context;
        }


        // GET: BatchStudents - displays the list of batch students with optional search functionality
        public async Task<IActionResult> Index(string searchBatchStudent)
        {
            if (_context.BatchStudents == null) // if the BatchStudents set is null, return a problem message
            {
                return Problem("Entity set 'TuitionDbContext.BatchStudents' is null.");
            }



            var batchStudentSearch = _context.BatchStudents
                                             .Include(b => b.Batches)
                                             .Include(b => b.Students)
                                             .AsQueryable(); // includes relevant data needed or the index's searching capability

            if (!String.IsNullOrEmpty(searchBatchStudent)) // if a search string is provided, filter the results
            {
                batchStudentSearch = batchStudentSearch.Where(s => s.Students.StudentFirstName.Contains(searchBatchStudent));
            }



            return View(await batchStudentSearch.ToListAsync()); // returns the view with the filtered list of batch students
        }

        // GET: BatchStudents/StudentsInBatch - displays the list of students in a specific batch
        public async Task<IActionResult> StudentsInBatch(int batchId)
        {


            var students = await _context.BatchStudents
                .Where(bs => bs.BatchId == batchId)
                .Select(bs => bs.Students)
                .ToListAsync(); // gets the list of students in the specified batch

            return View(students); // returns the view with the list of students
        }

        // GET: BatchStudents/Details/5 - displays the details of a specific batch student
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null) // if the id is null, return Error 404, page not found
            {
                return NotFound();
            }


            var batchStudent = await _context.BatchStudents
                .Include(bs => bs.Students)
                .Include(bs => bs.Batches)
                .ThenInclude(b => b.Staffs)
                .Include(bs => bs.Batches)
                .ThenInclude(b => b.Subjects)
                .FirstOrDefaultAsync(bs => bs.BatchStudentId == id); // searches the BatchStudents table and retrieves the data for a batch student

            if (batchStudent == null) // if the batch student value is null, return Error 404, page not found
            {
                return NotFound();
            }

            return View(batchStudent); // returns the details view with the batch student data
        }

        // GET: BatchStudents/Create - displays the create form for a new batch student
        public IActionResult Create()
        {


            ViewBag.BatchId = new SelectList(_context.Batches.Select(b => new
            {
                b.BatchId,
                BatchInfo = $"{b.BatchDay}, {b.BatchTime.ToString().Replace("Batch_", "").Insert(2, ":")}, {b.Subjects.SubjectName}, {b.Staffs.FullName}"
            }), "BatchId", "BatchInfo"); // prepares the batch data for the dropdown list in the view


            ViewBag.StudentId = new SelectList(_context.Students, "StudentId", "FullName", "StudentId", "StudentId"); // prepares the student data for the dropdown list in the view
            
            return View(); // returns the create view
        }

        // POST: BatchStudents/Create - handles the form submission for creating a new batch student

        [HttpPost] // data annotation for posting user input into the database

        [ValidateAntiForgeryToken] // validates the form by ensuring the request contains a valid anti-forgery token
        public async Task<IActionResult> Create([Bind("BatchStudentId,StudentId,BatchId")] BatchStudent batchStudent)
        {
          
            if (!ModelState.IsValid) // if the model state is valid
            {
                _context.Add(batchStudent); // adds the new batch student to the context
                await _context.SaveChangesAsync(); // asynchronously saves the changes to the database
                return RedirectToAction(nameof(Index)); // redirects to the index action
            }

            return View(batchStudent); // returns the create view with the batch student data
        }

        // GET: BatchStudents/Edit/5 - displays the edit form for a specific batch student
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null) // if the id is null, return Error 404, page not found
            {
                return NotFound();
            }

            var batchStudent = await _context.BatchStudents.FindAsync(id); // finds the batch student depending on the id

            if (batchStudent == null) // if the batch student value is null, return Error 404, page not found
            {
                return NotFound();
            }

           
            
           ViewBag.BatchId = new SelectList(_context.Batches.Select(b => new
            {
                b.BatchId,
                BatchInfo = $"{b.BatchDay}, {b.BatchTime.ToString().Replace("Batch_", "").Insert(2, ":")}, {b.Subjects.SubjectName}, {b.Staffs.FullName}"
            }), "BatchId", "BatchInfo"); // prepares the batch data for the dropdown list in the view

            ViewBag.StudentId = new SelectList(_context.Students, "StudentId", "FullName","StudentId", "StudentId"); // prepares the student data for the dropdown list in the view
            return View(batchStudent); // returns the edit view with the batch student data
        }

        // POST: BatchStudents/Edit/5 - handles the form submission for editing a specific batch student

        [HttpPost] // data annotation for posting user input into the database

        [ValidateAntiForgeryToken] // validates the form by ensuring the request contains a valid anti-forgery token
        public async Task<IActionResult> Edit(int id, [Bind("BatchStudentId,StudentId,BatchId")] BatchStudent batchStudent)
        {
            if (id != batchStudent.BatchStudentId) // if the id does not match the batch student record id, return Error 404, page not found
            {
                return NotFound();
            }

            if (!ModelState.IsValid) // if the model state is not valid
            {
                try
                {
                    _context.Update(batchStudent); // tries to update the batch student record
                    await _context.SaveChangesAsync(); // asynchronously saves the changes to the database
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BatchStudentExists(batchStudent.BatchStudentId)) // if the batch student record does not exist, return Error 404, page not found
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
           
            return View(batchStudent); // returns the edit view with the batch student data
        }

        // GET: BatchStudents/Delete/5 - displays the delete view for a specific batch student
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null) // if the id is null, return Error 404, page not found
            {
                return NotFound();
            }

          
            var batchStudent = await _context.BatchStudents
                .Include(bs => bs.Batches)
                    .ThenInclude(b => b.Staffs)
                .Include(bs => bs.Batches)
                    .ThenInclude(b => b.Subjects)
                .Include(bs => bs.Students)
                .FirstOrDefaultAsync(bs => bs.BatchStudentId == id); // finds the batch student record with related data

            if (batchStudent == null) // if the batch student value is null, return Error 404, page not found
            {
                return NotFound();
            }

         
            return View(batchStudent); // returns the delete view with the batch student data
        }

        // POST: BatchStudents/Delete/5 - handles the form submission for deleting a specific batch student

        [HttpPost, ActionName("Delete")] // data annotation for posting user input into the database

        [ValidateAntiForgeryToken] // validates the form by ensuring the request contains a valid anti-forgery token
        public async Task<IActionResult> DeleteConfirmed(int id)
       
        {
            var batchStudent = await _context.BatchStudents.FindAsync(id); // finds the batch student record with respect to BatchStudentId
            if (batchStudent != null) // if the batch student record is not null, remove it from the context
            {
                _context.BatchStudents.Remove(batchStudent);
            }

            await _context.SaveChangesAsync(); // asynchronously saves the changes to the database
            return RedirectToAction(nameof(Index)); // redirects to the index action
        }

        private bool BatchStudentExists(int id) //  checks if the batchstudent record exists depending on their id, then returns true if record exists, and false if record doesnt exist
        {
       
            return _context.BatchStudents.Any(e => e.BatchStudentId == id);
        }
    }
}
