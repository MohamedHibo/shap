using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

using shap.context;
using shap.Models;
using shap.Repository;

namespace shap.Controllers
{
    [Authorize]
    public class ProjectController : Controller
    {
        
        IProjectRepository projectRepository;
        public ProjectController(IProjectRepository projectRepository)
        {
            this.projectRepository = projectRepository;
        }

        public IActionResult Index()
        {
            var pro=projectRepository.GetAll();
            return View(pro);
        }
        [HttpGet]
        public IActionResult Create () 
        {
            ViewBag.Departments = projectRepository.Depart();
            return View();
        }
        [HttpPost]
        public IActionResult Create(Project pro) 
        {
            
           projectRepository.Save(pro);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult Edit(int id) 
        { var pro = projectRepository.Find(id);
            return View(pro);
        }
        [HttpPost]
        public ActionResult Edit(Project pro)
        {
            projectRepository.Update(pro);
            return RedirectToAction("Index");
        }
        
        public IActionResult Details(int id)
        {
            var pro = projectRepository.Find(id);
            return View(pro);

        }
        public IActionResult Delete(int id)
        {
            projectRepository.Delete(id);
            return RedirectToAction("Index");
        }
    }
}
