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

        public IQueryable<Employee> Employees => _context.Employees.Include(e => e.EmployeeProject).ThenInclude(e => e.Project);

        public IQueryable<Project> AllProjects => _context.Projects.Include(p => p.EmployeeProject).ThenInclude(p => p.Employee);
        
        
        public void Add(Employee employee)
        {
            
            employee.EmployeeProject = new List<EmployeeProject>();
            if (employee.ChoosedProjectID != 0)
            {
                employee.EmployeeProject.Add(new EmployeeProject { EmployeeID = employee.EmployeeID, ProjectID = AllProjects.FirstOrDefault(e => e.ProjectID == employee.ChoosedProjectID).ProjectID });
            }
           
            _context.Employees.Add(employee);
            _context.SaveChanges();
        }
        public void Edit(Employee employee)
        {
            Employee dbEntry = _context.Employees.FirstOrDefault(e => e.EmployeeID == employee.EmployeeID);
            if (dbEntry != null)
            {
                dbEntry.Name = employee.Name;
                dbEntry.SecondName = employee.SecondName;
                dbEntry.PhoneNumber = employee.PhoneNumber;
                dbEntry.HeadOfProjectID = employee.HeadOfProjectID;
                dbEntry.Email = employee.Email;
                if (employee.ChoosedProjectID != dbEntry.ChoosedProjectID) dbEntry.EmployeeProject = new List<EmployeeProject> { new EmployeeProject { EmployeeID = employee.EmployeeID, ProjectID = employee.ChoosedProjectID } };
                _context.Employees.Update(dbEntry);
          
            }
            _context.SaveChanges();
        }
        public void Delete(int employeeId)
        {
            _context.Remove(_context.Employees.FirstOrDefault(e => e.EmployeeID == employeeId));
            _context.SaveChanges();
        }

    }
}
