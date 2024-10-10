using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using shap.Models;

namespace shap.context
{
    public class appContext : IdentityDbContext<ApplicationUser>
    {
        public appContext() : base()
        {

        }
        //injection
        public appContext(DbContextOptions options) : base(options)
        {

        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=DESKTOP-Q6Q8TVP;Database=TASK04;Trusted_Connection=True;Encrypt=false");
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            var emp = new List<Employee>
            {
                new Employee { Id = 1, Name ="mohamed" ,Salary=5000, DepartmentId=1 },
                new Employee { Id = 2, Name ="ahmed" ,Salary=3000 , DepartmentId=2},
                new Employee { Id = 3, Name ="ali" ,Salary=6000 , DepartmentId = 1},
                new Employee { Id = 4, Name ="wael" ,Salary=7000 , DepartmentId=2}

            };


            var depart = new List<Department>
            {
                new Department { Id = 1,  Name = "custmar", shap = "shap" },
                new Department { Id = 2,  Name = "mo", shap = "shaps" }
            };


            modelBuilder.Entity<Employee>().HasData(emp);
            modelBuilder.Entity<Department>().HasData(depart);
        }
        public DbSet<Employee> employees { get; set; }
        public DbSet<Department> department{get; set; }
        public DbSet<Project> Projects { get; set; }
    } 
}
