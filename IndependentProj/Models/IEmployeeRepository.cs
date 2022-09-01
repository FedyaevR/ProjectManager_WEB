namespace IndependentProj.Models
{
    public interface IEmployeeRepository
    {
        IQueryable<Employee> Employees { get; }
        IQueryable<Project> AllProjects { get; }
        void Add(Employee employee);
        void Edit(Employee employee);
        void Delete(int employeeId);
        IQueryable<Employee> Show(Employee employee);
    }
}
