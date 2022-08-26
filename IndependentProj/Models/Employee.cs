using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace IndependentProj.Models
{
    public class Employee
    {

        [Key]
        public int EmployeeID { get; set; }
        [Required(ErrorMessage = "The name is required")]
        public string Name { get; set; }
        [Required(ErrorMessage = "The Second Name is required")]
        public string SecondName { get; set; }
        [Display( Name = "Email Address")]
        [Required(ErrorMessage = "Email is required")]
        [EmailAddress(ErrorMessage = "Invalid address")]
        public string Email { get; set; }
        [Required(ErrorMessage = "You must provide a phone number")]
        [Display(Name = "Number of employee")]
        [RegularExpression("^\\+?\\d{1,4}?[-.\\s]?\\(?\\d{1,3}?\\)?[-.\\s]?\\d{1,4}[-.\\s]?\\d{1,4}[-.\\s]?\\d{1,9}$")]
        public string PhoneNumber { get; set; }
        [ValidateNever]
        public int ChoosedProjectID { get; set; }
        [ValidateNever]
        public int HeadOfProjectID { get; set; }
        [ValidateNever]
        public List<EmployeeProject> EmployeeProject { get; set; }
        

    }
}
