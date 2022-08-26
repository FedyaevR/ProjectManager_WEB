using IndependentProj.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace IndependentProj.Controllers
{
    //TODO Rename to EmployeeController
    public class EmployeeController : Controller
    {
        private IEmployeeRepository _repository;
        public EmployeeController(IEmployeeRepository repository)
        {
            _repository = repository;
        }
        public ViewResult Index() => View(_repository.Employees.Include(e => e.EmployeeProject).ThenInclude(e => e.Project));
        public ViewResult AddEmployee() 
        {
            ViewBag.AllProjects = _repository.AllProjects;
            return View(new Employee());
        }

        [HttpPost]
        public IActionResult AddEmployee(Employee employee)
        {
            if (ModelState.IsValid)
            {
                _repository.Add(employee);
                return RedirectToAction("Index");
            }
            else
            {
                return View(employee);
            }

        }
    }
}
