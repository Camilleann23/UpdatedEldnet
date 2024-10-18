using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using StudentPortal.Web.Data;
using StudentPortal.Web.Models;
using StudentPortal.Web.Models.Entities;

namespace StudentPortal.Web.Controllers
{
    public class ScheduleController : Controller
    {
        private readonly ApplicationDbContext dbContext;

        public ScheduleController(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Add(AddScheduleViewModel viewModel)
        {
            using (var transaction = await dbContext.Database.BeginTransactionAsync())
            {
                await dbContext.Database.ExecuteSqlRawAsync($"SET IDENTITY_INSERT Schedule ON");

                var schedule = new Schedule
                {
                    SubjectCode = viewModel.SubjectCode,
                    Description = viewModel.Description,
                    Section = viewModel.Section,
                    StartTime = viewModel.StartTime,
                    EndTime = viewModel.EndTime,
                    Days = viewModel.Days,
                    AMPM = viewModel.AMPM,
                    Room = viewModel.Room,
                    CurriculumYear = viewModel.CurriculumYear

                };
                await dbContext.Schedule.AddAsync(schedule);
                await dbContext.SaveChangesAsync();

                await dbContext.Database.ExecuteSqlRawAsync($"SET IDENTITY_INSERT Schedule OFF");

                await transaction.CommitAsync();

                return RedirectToAction("List", "Schedule");
            }


            return View(viewModel);
        }

        [HttpGet]
        public async Task<IActionResult> List()
        {
            var schedule = await dbContext.Schedule.ToListAsync();
            return View(schedule);
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int? SubjectCode)
        {
            var schedule = await dbContext.Schedule.FindAsync(SubjectCode);
            return View(schedule);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(Schedule viewModel)
        {
            if (ModelState.IsValid)
            {
                var schedule = await dbContext.Schedule.FindAsync(viewModel.SubjectCode);
                if (schedule != null)
                {

                    schedule.SubjectCode = viewModel.SubjectCode;
                    schedule.Description = viewModel.Description;
                    schedule.Section = viewModel.Section;
                    schedule.StartTime = viewModel.StartTime;
                    schedule.EndTime = viewModel.EndTime;
                    schedule.Days = viewModel.Days;
                    schedule.AMPM = viewModel.AMPM;
                    schedule.Room = viewModel.Room;
                    schedule.CurriculumYear = viewModel.CurriculumYear;

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
            var schedule = await dbContext.Schedule.FindAsync(SubjectCode);
            if (schedule != null)
            {
                dbContext.Schedule.Remove(schedule);
                await dbContext.SaveChangesAsync();
            }
            return RedirectToAction("List");
        }
    }
}