namespace IndependentProj.Models
{
    public interface IProjectRepository
    {
        IQueryable<Project> Projects { get; }
        IQueryable<Employee> AllEmployees { get; }
        void Add(Project project);
        void Edit(Project project);
        void Delete(int projectId);
        IQueryable<Project> Show(Project employee);
    }
}
