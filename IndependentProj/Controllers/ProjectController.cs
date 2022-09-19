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

        public ViewResult Index() => View(_repository.Projects);//.Include(p => p.EmployeeProject).ThenInclude(p => p.Employee)

        public ViewResult AddProject()
        {
            ViewBag.AllEmployees = _repository.AllEmployees;
            ViewBag.NoHeadOfProject = _repository.AllEmployees.Where(e => e.EmployeeProject.All(e => e.Project.HeadOfProjectID != e.EmployeeID));
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
            ViewBag.NoHeadOfProject = _repository.AllEmployees.Where(e => e.EmployeeProject.All(e => e.Project.HeadOfProjectID != e.EmployeeID));
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
        [HttpPost]
        public RedirectToActionResult DeleteProject(int projectId)
        {
            _repository.Delete(projectId);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ViewResult OrderByPriority(Priority priority)
        {
            if(priority != _repository.Projects.Min(p => p.Priority)) return View("Index", _repository.Projects.OrderBy(p => p.Priority));
            else return View("Index", _repository.Projects.OrderByDescending(p => p.Priority));
        }
        [HttpGet]
        public ViewResult OrderByStartDate(DateTime date)
        {
            if (date != _repository.Projects.Min(p => p.StartDate)) return View("Index", _repository.Projects.OrderBy(p => p.StartDate));
            else return View("Index", _repository.Projects.OrderByDescending(p => p.StartDate));
        }
        [HttpGet]
        public ViewResult FilterDate(DateTime startDate_1, DateTime startDate_2)
        {
            var re = startDate_1;
            var res = startDate_2;

            return View("Index");
        }
    }

}
