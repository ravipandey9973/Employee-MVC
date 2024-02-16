using Employee.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace Employee.Data
{
    public class EmployeeDBContext:DbContext
    {
        public EmployeeDBContext(DbContextOptions<EmployeeDBContext>options):base (options)
        {
            
        }
        public DbSet<Staff> Staffs { get; set;}
    }
}
