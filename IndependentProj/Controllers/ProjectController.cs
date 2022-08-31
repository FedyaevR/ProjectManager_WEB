using IndependentProj.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace IndependentProj.Controllers
{
    public class ProjectController : Controller
    {
        private IProjectRepository _repository;
        private List<EmployeeProject> _employeeProjects;
        public ProjectController(IProjectRepository repository)
        {
            _repository = repository;
        }

        public ViewResult Index() => View(_repository.Projects.Include(p => p.EmployeeProject).ThenInclude(p => p.Employee));

        public ViewResult AddProject()
        {
            ViewBag.AllEmployees = _repository.AllEmployees;
            return View(new Project());
        }

            [HttpPost]
        public IActionResult AddProject(Project project)
        {
            if (ModelState.IsValid)
            {

                _repository.Add(project);
                return RedirectToAction("Index");
            }
            else
            {
                return View(project);
            }
            
        }
        [HttpGet]
        public ViewResult EditProject(int projectId)
        {
            ViewBag.AllEmployees = _repository.AllEmployees;
            return View( _repository.Projects.FirstOrDefault(p => p.ProjectID == projectId));
        }
        [HttpPost]
        public IActionResult EditProject(Project project)
        {

            if (ModelState.IsValid)
            {
                _repository.Edit(project);
                return RedirectToAction("Index");
            }
            else
            {
                return View(project);
            }

        }
    }

}
