using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.EntityFrameworkCore;
using shap.context;
using shap.Models;
using shap.Repository;

namespace shap.Controllers
{
    [Authorize]
    public class DepartmentController : Controller
    {
       appContext context= new appContext();
        IDepartmentRepository departmentRepository;
        public DepartmentController(IDepartmentRepository department)
        {
            departmentRepository= department;

        }
        public IActionResult Index()
        {
            var dept = departmentRepository.GetAll();

           ViewBag.Project = departmentRepository.pro(dept);

            return View(dept);
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Department d)
        {
            departmentRepository.Save(d);
            return RedirectToAction("index");
        }
        [HttpGet]
        public IActionResult Edit(int id) 
        {
            var d = departmentRepository.Find(id);
            return View(d);
        }
        [HttpPost]
        public IActionResult Edit(Department department)
        {
           departmentRepository.Update(department);
            return RedirectToAction("index");
        }
        [HttpGet]
        public IActionResult Details(int id)
        {
             var pro = departmentRepository.FindPro(id);
           
            ViewBag.Project = pro.Name;
            var c = departmentRepository.Find(id);
            return View(c);
        }


        [HttpGet]
        public IActionResult Delete(int id)
        {
           departmentRepository.Delete(id);
            return RedirectToAction("index");
        }
    }
}
