using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using StudentPortal.Web.Data;
using StudentPortal.Web.Models;
using StudentPortal.Web.Models.Entities;

namespace StudentPortal.Web.Controllers
{
    public class SubjectsController : Controller
    {
        private readonly ApplicationDbContext dbContext;

        public SubjectsController(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Add(AddSubjectViewModel viewModel)
        {
            using (var transaction = await dbContext.Database.BeginTransactionAsync())
            {
                await dbContext.Database.ExecuteSqlRawAsync($"SET IDENTITY_INSERT Subjects ON");

                var subject = new Subject
                {
                    SubjectCode = viewModel.SubjectCode,
                    SubjectName = viewModel.SubjectName,
                    Description = viewModel.Description,
                    Units = viewModel.Units,
                    Offering = viewModel.Offering,
                    Category = viewModel.Category,
                    CourseCode = viewModel.CourseCode,
                    CurriculumYear = viewModel.CurriculumYear,
                    Requisite = viewModel.Requisite


                };
                await dbContext.Subjects.AddAsync(subject);
                await dbContext.SaveChangesAsync();

                await dbContext.Database.ExecuteSqlRawAsync($"SET IDENTITY_INSERT Subjects OFF");

                await transaction.CommitAsync();

                return RedirectToAction("List", "Subjects");
            }


            return View(viewModel);
        }

        [HttpGet]
        public async Task<IActionResult> List()
        {
            var subjects = await dbContext.Subjects.ToListAsync();
            return View(subjects);
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int? SubjectCode)
        {
            var subject = await dbContext.Subjects.FindAsync(SubjectCode);
            return View(subject);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(Subject viewModel)
        {
            if (ModelState.IsValid)
            {
                var subject = await dbContext.Subjects.FindAsync(viewModel.SubjectCode);
                if (subject != null)
                {
                    subject.SubjectCode = viewModel.SubjectCode;
                    subject.SubjectName = viewModel.SubjectName;
                    subject.Description = viewModel.Description;
                    subject.Units = viewModel.Units;
                    subject.Offering = viewModel.Offering;
                    subject.Category = viewModel.Category;
                    subject.CourseCode = viewModel.CourseCode;
                    subject.CurriculumYear = viewModel.CurriculumYear;
                    subject.Requisite = viewModel.Requisite;

                    await dbContext.SaveChangesAsync();
                    return RedirectToAction("List");
                }
                return NotFound();
            }
            return View(viewModel);
        }

        [HttpPost]
        public async Task<IActionResult> Delete(int SubjectCode)
        {
            var subject = await dbContext.Subjects.FindAsync(SubjectCode);
            if (subject != null)
            {
                dbContext.Subjects.Remove(subject);
                await dbContext.SaveChangesAsync();
            }
            return RedirectToAction("List");
        }
    }
}