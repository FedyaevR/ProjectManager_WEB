using Microsoft.EntityFrameworkCore;
using Microsoft.VisualBasic;
using System.Runtime.CompilerServices;

namespace IndependentProj.Models
{
    public class ApplicationDbContext:DbContext
    {
        public DbSet<Employee> Employees { get; set; } = null!;
        public DbSet<Project> Projects { get; set; } = null!;
        public DbSet<EmployeeProject> EmployeeProjects { get; set; } = null!;
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
            Database.EnsureCreated();
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
           
            //modelBuilder.Entity<Employee>().HasData(
            //   new Employee
            //   {
            //       EmployeeID = 1,
            //       Name = "Bob",
            //       Email = "asdasd@mail.ru",
            //       SecondName = "Bobov",
            //       PhoneNumber = "79912301203",
            //       HeadOfProjectID = 1,
            //       ChoosedProjectID = 1,

            //   }
            //   );
            //modelBuilder.Entity<Project>().HasData(
            //    new Project
            //    {
            //        ProjectID = 1,
            //        CustomerCompanyName = "FristCustomer",
            //        PerformerCompanyName = "FirstPerformer",
            //        ProjectName = "FirstProject",
            //        StartDate = DateTime.Parse("2022-01-02"),
            //        DoneDate = DateTime.Parse("2022-04-05"),
            //        Priority = (Priority)1,
            //        HeadOfProjectID = 1,
            //        ChoosedEmployeeID = 1,
            //    }
            //    );
            modelBuilder.Entity<EmployeeProject>().HasKey(ep => new { ep.EmployeeID, ep.ProjectID });

            modelBuilder.Entity<EmployeeProject>().HasOne(ep => ep.Employee).WithMany(e => e.EmployeeProject).HasForeignKey(ep => ep.EmployeeID);
            modelBuilder.Entity<EmployeeProject>().HasOne(ep => ep.Project).WithMany(p => p.EmployeeProject).HasForeignKey(ep => ep.ProjectID);
            

        }

    }
}
