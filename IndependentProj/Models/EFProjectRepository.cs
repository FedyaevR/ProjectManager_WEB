namespace IndependentProj.Models
{
    public class EFProjectRepository : IProjectRepository
    {
        private ApplicationDbContext _context;
        public EFProjectRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public IQueryable<Project> Projects => _context.Projects;

        public IQueryable<Employee> AllEmployees => _context.Employees;
        

        public void Add(Project project)
        {
            project.EmployeeProject = new List<EmployeeProject>();
            project.EmployeeProject.Add(new EmployeeProject { ProjectID = project.ProjectID, EmployeeID = AllEmployees.FirstOrDefault(p => p.EmployeeID == project.ChoosedEmployeeID).EmployeeID });
            _context.Projects.Add(project);
            _context.SaveChanges();
        }

        public void Delete(Project project)
        {
            _context.Remove(project);
            _context.SaveChanges();
        }

        public IQueryable<Project> Show(Project employee)
        {
            return null;
        }
    }
}
