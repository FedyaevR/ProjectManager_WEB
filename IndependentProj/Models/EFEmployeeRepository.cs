using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace IndependentProj.Models
{
    public class EFEmployeeRepository : IEmployeeRepository
    {
        private ApplicationDbContext _context;
        public EFEmployeeRepository(ApplicationDbContext context)
        {
            _context = context;
            
        }

        public IQueryable<Employee> Employees => _context.Employees;

        public IQueryable<Project> AllProjects => _context.Projects;
        
        
        public void Add(Employee employee)
        {
            
            employee.EmployeeProject = new List<EmployeeProject>();
            employee.EmployeeProject.Add(new EmployeeProject { EmployeeID = employee.EmployeeID, ProjectID = AllProjects.FirstOrDefault(e => e.ProjectID == employee.ChoosedProjectID).ProjectID});
            _context.Employees.Add(employee);
            _context.SaveChanges();
        }

        public void Delete(Employee employee)
        {
            _context.Employees.Remove(employee);
            _context.SaveChanges();
        }

        public IQueryable<Employee> Show(Employee employee)
        {
            return _context.Employees;
        }
    }
}
