using Employee.Data;
using Employee.Models;
using Employee.Models.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Employee.Controllers
{
    public class StaffsController : Controller
    {
        private readonly EmployeeDBContext DbContext;
        public StaffsController(EmployeeDBContext DbContext)
        {
            this.DbContext = DbContext;
        }
        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Add(StaffViewModel viewModel)
        {
            var staff = new Staff
            {
                Name = viewModel.Name,
                Department = viewModel.Department,
                DateOfJoining = viewModel.DateOfJoining,
                Subscribed = viewModel.Subscribed

            };
            await DbContext.Staffs.AddAsync(staff);
            await DbContext.SaveChangesAsync();

            return View(viewModel);
        }
        [HttpGet]
        public async Task<IActionResult> List()
        {
            var staff = await DbContext.Staffs.ToListAsync();
            return View(staff);
        }

        [HttpGet]
        public async Task<IActionResult> Edit(Guid id)
        {
            var staff = await DbContext.Staffs.FindAsync(id);
            return View(staff);
        }
        [HttpPost]
        public async Task<IActionResult> Edit(Staff viewModel)
        {
            var staff = await DbContext.Staffs.FindAsync(viewModel.Id);
            if (staff is not null)
            {
                staff.Name = viewModel.Name;
                staff.Department = viewModel.Department;
                staff.DateOfJoining = viewModel.DateOfJoining;
                staff.Subscribed = viewModel.Subscribed;


                await DbContext.SaveChangesAsync();
            }

            return RedirectToAction("List", "Staffs");
        }
        [HttpPost]
        public async Task<IActionResult> Delete(Staff viewModel)
        {
            var staff= await DbContext.Staffs.AsNoTracking().SingleOrDefaultAsync(X=>X.Id == viewModel.Id);
            if(staff is not null)
            {
                DbContext.Staffs.Remove(viewModel);
                await DbContext.SaveChangesAsync();
            }
            return RedirectToAction("List", "Staffs");
        }
        
    }
}
