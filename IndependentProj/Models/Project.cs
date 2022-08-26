using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace IndependentProj.Models
{
    public class Project
    {
        [Key]
        public int ProjectID { get; set; }
        [Required(ErrorMessage = "Enter the Project Name")]
        public string ProjectName { get; set; }
        [Required(ErrorMessage = "Enter the Customer Company name")]
        public string CustomerCompanyName { get; set; }
        [Required(ErrorMessage = "Enter the Performer Company name")]
        public string PerformerCompanyName { get; set; }
        [BindProperty]
        [DataType(DataType.Date)]
        public DateTime StartDate { get; set; } = DateTime.Parse("01-01-2005");
        [BindProperty]
        [DataType(DataType.Date)]
        public DateTime DoneDate { get; set; } = DateTime.Parse("01-01-2005");
        [Required(ErrorMessage = "Choose the priority of project")]
        public Priority Priority { get; set; }
        [ValidateNever]
        public int ChoosedEmployeeID { get; set; }
        [ValidateNever]
        public int HeadOfProjectID { get; set; }
        [ValidateNever]
        public List<EmployeeProject> EmployeeProject { get; set; }
    }
    public enum Priority
    {
        Low = 1,
        Medium = 2,
        High = 3,
        VeryHigh = 4
    }
}
