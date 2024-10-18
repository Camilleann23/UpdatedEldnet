using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using StudentPortal.Web.Data;
using StudentPortal.Web.Models;
using StudentPortal.Web.Models.Entities;

namespace StudentPortal.Web.Controllers
{
    public class StudentsController : Controller
    {
        private readonly ApplicationDbContext dbContext;

        public StudentsController(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Add(AddStudentViewModel viewModel)
        {
            using (var transaction = await dbContext.Database.BeginTransactionAsync())
            {
                await dbContext.Database.ExecuteSqlRawAsync($"SET IDENTITY_INSERT Students ON");

                var student = new Student
                {
                    ID = viewModel.ID,
                    FName = viewModel.FName,
                    LName = viewModel.LName,
                    Course = viewModel.Course,
                    Year = viewModel.Year,
                    Status = viewModel.Status
                };
                await dbContext.Students.AddAsync(student);
                await dbContext.SaveChangesAsync();

                await dbContext.Database.ExecuteSqlRawAsync($"SET IDENTITY_INSERT Students OFF");

                await transaction.CommitAsync();

                return RedirectToAction("List", "Students");
            }
                
            
            return View(viewModel);
        }

        [HttpGet]
        public async Task<IActionResult> List()
        {
            var students = await dbContext.Students.ToListAsync();
            return View(students);
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int? id)
        {
            var student = await dbContext.Students.FindAsync(id);
            return View(student);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(Student viewModel)
        {
            if (ModelState.IsValid)
            {
                var student = await dbContext.Students.FindAsync(viewModel.ID);
                if (student != null)
                {
                    student.FName = viewModel.FName;
                    student.LName = viewModel.LName;
                    student.Course = viewModel.Course;
                    student.Year = viewModel.Year;
                    student.Status = viewModel.Status;

                    await dbContext.SaveChangesAsync();
                    return RedirectToAction("List");
                }
                return NotFound(); 
            }
            return View(viewModel);
        }

        [HttpPost]
        public async Task<IActionResult> Delete(int id)
        {
            var student = await dbContext.Students.FindAsync(id);
            if (student != null)
            {
                dbContext.Students.Remove(student);
                await dbContext.SaveChangesAsync();
            }
            return RedirectToAction("List");
        }
    }
}