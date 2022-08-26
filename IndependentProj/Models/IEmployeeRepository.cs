namespace IndependentProj.Models
{
    public interface IEmployeeRepository
    {
        IQueryable<Employee> Employees { get; }
        IQueryable<Project> AllProjects { get; }
        void Add(Employee employee);
        void Delete(Employee employee);
        IQueryable<Employee> Show(Employee employee);
    }
}
