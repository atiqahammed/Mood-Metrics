using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SytnerCollege.Data;
using SytnerCollege.Models;
using SytnerCollege.Models.CollegeViewModels;

namespace Sytner_College.Controllers
{
    public class LecturersController : Controller
    {
        private readonly CollegeContext _context;

        public LecturersController(CollegeContext context)
        {
            _context = context;
        }

        // GET: Lecturers
        public async Task<IActionResult> Index(int? id, int? courseID)
        {
            /*The code repeats CourseAssignments and Course because the two properties from Course, 
             * are needed to show the courses assigned to the lecturer. 
             * The first string of 'ThenInclude' calls gets CourseAssignment.Course, Course.Enrollments, and Enrollment.Student
             * 
             * 'Include' starts over with Lecturer properties, so you have to go through the chain again, 
             *  specifying Course.Department instead of Course.Enrollments
             */
            var viewModel = new LecturerIndexData();
            viewModel.Lecturers = await _context.Lecturers
                  .Include(i => i.OfficeAssignment)
                  .Include(i => i.CourseAssignments)
                    .ThenInclude(i => i.Course)
                        .ThenInclude(i => i.Enrollments)
                            .ThenInclude(i => i.Student)
                  .Include(i => i.CourseAssignments)
                    .ThenInclude(i => i.Course)
                        .ThenInclude(i => i.Department)
                  .AsNoTracking()
                  .OrderBy(i => i.LastName)
                  .ToListAsync();

            if (id != null)
            {
                ViewData["LecturerID"] = id.Value;
                Lecturer instructor = viewModel.Lecturers.Where(
                    i => i.ID == id.Value).Single();
                viewModel.Courses = instructor.CourseAssignments.Select(s => s.Course);
            }

            if (courseID != null)
            {
                ViewData["CourseID"] = courseID.Value;
                viewModel.Enrollments = viewModel.Courses.Where(
                    x => x.CourseID == courseID).Single().Enrollments;
            }

            return View(viewModel);
        }

        // GET: Lecturers/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var lecturer = await _context.Lecturers
                .SingleOrDefaultAsync(m => m.ID == id);
            if (lecturer == null)
            {
                return NotFound();
            }

            return View(lecturer);
        }

        // GET: Lecturers/Create
        public IActionResult Create()
        {
            var lecturer = new Lecturer();
            lecturer.CourseAssignments = new List<CourseAssignment>();
            PopulateAssignedCourseData(lecturer);
            return View();
        }

        // POST: Lecturers/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("FirstMidName,HireDate,LastName,OfficeAssignment")] Lecturer lecturer, string[] selectedCourses)
        {
            if (selectedCourses != null)
            {
                lecturer.CourseAssignments = new List<CourseAssignment>();
                foreach (var course in selectedCourses)
                {
                    var courseToAdd = new CourseAssignment { LecturerID = lecturer.ID, CourseID = int.Parse(course) };
                    
                    lecturer.CourseAssignments.Add(courseToAdd);
                }
            }
            if (ModelState.IsValid)
            {
                _context.Add(lecturer);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            PopulateAssignedCourseData(lecturer);

            return View(lecturer);
        }

        // GET: Lecturers/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var instructor = await _context.Lecturers
                .Include(i => i.OfficeAssignment)
                .Include(i => i.CourseAssignments).ThenInclude(i => i.Course)
                .AsNoTracking()
                .SingleOrDefaultAsync(m => m.ID == id);
            if (instructor == null)
            {
                return NotFound();
            }
            PopulateAssignedCourseData(instructor);
            return View(instructor);
        }

        private void PopulateAssignedCourseData(Lecturer tutor)
        {
            var allCourses = _context.Courses;
            var instructorCourses = new HashSet<int>(tutor.CourseAssignments.Select(c => c.CourseID));
            var viewModel = new List<AssignedCourseData>();
            foreach (var course in allCourses)
            {
                viewModel.Add(new AssignedCourseData
                {
                    CourseID = course.CourseID,
                    Title = course.Title,
                    Assigned = instructorCourses.Contains(course.CourseID)
                });
            }
            ViewData["Courses"] = viewModel;
        }

        // POST: Lecturers/Edit/5
        [HttpPost, ActionName("Edit")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int? id, string[] selectedCourses)
        {
            if (id == null)
            {
                return NotFound();
            }

            var instructorToUpdate = await _context.Lecturers
                .Include(i => i.OfficeAssignment)
                .Include(i => i.CourseAssignments)
                .ThenInclude(i => i.Course)
                .SingleOrDefaultAsync(s => s.ID == id);

            if (await TryUpdateModelAsync<Lecturer>(
                instructorToUpdate,
                "",
                i => i.FirstMidName, i => i.LastName, i => i.HireDate, i => i.OfficeAssignment))
            {
                if (String.IsNullOrWhiteSpace(instructorToUpdate.OfficeAssignment?.Location))
                {
                    instructorToUpdate.OfficeAssignment = null;
                }
                UpdateLecturerCourses(selectedCourses, instructorToUpdate); //update the lecturer based on the selected course.
                try
                {
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateException /* ex */)
                {
                    //Log the error (uncomment ex variable name and write a log.)
                    ModelState.AddModelError("", "Unable to save changes. " +
                        "Try again, and if the problem persists, " +
                        "see your system administrator.");
                }
                UpdateLecturerCourses(selectedCourses, instructorToUpdate);
                PopulateAssignedCourseData(instructorToUpdate);
                return RedirectToAction("Index");
            }
            return View(instructorToUpdate);
        }

        //This method updates the lecturer based on the selected course. 
        private void UpdateLecturerCourses(string[] selectedCourses, Lecturer instructorToUpdate)
        {
            /*
             If there are no checkboxes selected, this method will 
             initializes the CourseAssignments navigation property with an empty collection and returns
             */
            if (selectedCourses == null)
            {
                instructorToUpdate.CourseAssignments = new List<CourseAssignment>();
                return;
            }

            var selectedCoursesHS = new HashSet<string>(selectedCourses);
            var instructorCourses = new HashSet<int>
                (instructorToUpdate.CourseAssignments.Select(c => c.Course.CourseID));
            foreach (var course in _context.Courses)
            {
                if (selectedCoursesHS.Contains(course.CourseID.ToString()))
                {
                    if (!instructorCourses.Contains(course.CourseID))
                    {
                        instructorToUpdate.CourseAssignments.Add(new CourseAssignment { LecturerID = instructorToUpdate.ID, CourseID = course.CourseID });
                    }
                }
                else
                {

                    if (instructorCourses.Contains(course.CourseID))
                    {
                        CourseAssignment courseToRemove = instructorToUpdate.CourseAssignments.SingleOrDefault(i => i.CourseID == course.CourseID);
                        _context.Remove(courseToRemove);
                    }
                }
            }
        }

        // GET: Lecturers/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var lecturer = await _context.Lecturers
                .SingleOrDefaultAsync(m => m.ID == id);
            if (lecturer == null)
            {
                return NotFound();
            }

            return View(lecturer);
        }

        // POST: Lecturers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            Lecturer instructor = await _context.Lecturers
             .Include(i => i.CourseAssignments) //Does eager loading for the CourseAssignments navigation property.
             .SingleAsync(i => i.ID == id);

            var departments = await _context.Departments
                .Where(d => d.LecturerID == id) 
                .ToListAsync();
            departments.ForEach(d => d.LecturerID = null); 

            var lecturer = await _context.Lecturers.SingleOrDefaultAsync(m => m.ID == id);
            _context.Lecturers.Remove(lecturer);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        private bool LecturerExists(int id)
        {
            return _context.Lecturers.Any(e => e.ID == id);
        }
    }
}
