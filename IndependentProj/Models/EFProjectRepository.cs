using Microsoft.EntityFrameworkCore;

namespace IndependentProj.Models
{
    public class EFProjectRepository : IProjectRepository
    {
        private ApplicationDbContext _context;
        public EFProjectRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public IQueryable<Project> Projects => _context.Projects.Include(p => p.EmployeeProject).ThenInclude(p => p.Employee);

        public IQueryable<Employee> AllEmployees => _context.Employees.Include(e => e.EmployeeProject).ThenInclude(e => e.Project);
        

        public void Add(Project project)
        {
            project.EmployeeProject = new List<EmployeeProject>();
            if(project.ChoosedEmployeeID != 0)
            {
                project.EmployeeProject.Add(new EmployeeProject { ProjectID = project.ProjectID, EmployeeID = AllEmployees.FirstOrDefault(p => p.EmployeeID == project.ChoosedEmployeeID).EmployeeID });
            }
           
            _context.Projects.Add(project);
            _context.SaveChanges();
        }
        public void Edit(Project project)
        {
            Project dbEntry = _context.Projects.FirstOrDefault(p => p.ProjectID == project.ProjectID);
            if (dbEntry != null)
            {
                dbEntry.ProjectName = project.ProjectName;
                dbEntry.CustomerCompanyName = project.CustomerCompanyName;
                dbEntry.PerformerCompanyName = project.PerformerCompanyName;
                dbEntry.StartDate = project.StartDate;
                dbEntry.DoneDate = project.DoneDate;
                dbEntry.Priority = project.Priority;
                dbEntry.HeadOfProjectID = project.HeadOfProjectID;
                if(project.ChoosedEmployeeID != dbEntry.ChoosedEmployeeID) dbEntry.EmployeeProject = new List<EmployeeProject> { new EmployeeProject { ProjectID = project.ProjectID, EmployeeID = project.ChoosedEmployeeID } };
                _context.Projects.Update(dbEntry);
            }
            _context.SaveChanges();
        }

        public void Delete(int projectId)
        {

            _context.Remove(_context.Projects.FirstOrDefault(p => p.ProjectID == projectId));
            _context.SaveChanges();
        }

        public IQueryable<Project> Show(Project employee)
        {
            return null;
        }
    }
}
