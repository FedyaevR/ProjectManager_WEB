namespace IndependentProj.Models
{
    public class EmployeeProject
    {
        public int EmployeeID { get; set; }
        public Employee Employee { get; set; }

        public int ProjectID { get; set; }
        public Project Project { get; set; }
    }
}
