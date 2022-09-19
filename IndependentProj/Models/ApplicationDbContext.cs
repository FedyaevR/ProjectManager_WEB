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
            modelBuilder.Entity<EmployeeProject>().HasKey(ep => new { ep.EmployeeID, ep.ProjectID });

            modelBuilder.Entity<EmployeeProject>().HasOne(ep => ep.Employee).WithMany(e => e.EmployeeProject).HasForeignKey(ep => ep.EmployeeID);
            modelBuilder.Entity<EmployeeProject>().HasOne(ep => ep.Project).WithMany(p => p.EmployeeProject).HasForeignKey(ep => ep.ProjectID);
            

        }

    }
}
