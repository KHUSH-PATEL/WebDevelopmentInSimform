using Microsoft.EntityFrameworkCore;
using WebDevelopmentAPI.Model;

namespace WebDevelopmentAPI.Data
{
    public class ApplicationContext :DbContext
    {
        public ApplicationContext(DbContextOptions<ApplicationContext> options):base(options)
        {
        }
        public DbSet<Department> Departments { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<EmployeeDesignation> EmployeesDesignations { get; set;}    
    }
}
