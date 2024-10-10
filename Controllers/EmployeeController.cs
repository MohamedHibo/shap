using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis;
using Microsoft.EntityFrameworkCore;
using shap.context;
using shap.Models;
using shap.Repository;

namespace shap.Controllers
{
    [Authorize]
    public class EmployeeController : Controller
    {
        private readonly IEmployeeRepository employeeRepository;

        public EmployeeController (IEmployeeRepository employee)
        {
            employeeRepository= employee;
        }

        public IActionResult Index()
        {
            var emp = employeeRepository.GetAll();
            ViewBag.depart = employeeRepository.DepartmentNames(emp);
            return View(emp);
        }
        public IActionResult Details(int id)
        {
            var employee = employeeRepository.FindById(id);

            if (employee == null)
                return NotFound();
            
            ViewBag.Department = employeeRepository.DepartmentName(employee);
            ViewBag.Projects = employeeRepository.Proj(id);

            return View(employee);
        }

        [HttpGet]
        public IActionResult Create()
        {
            ViewBag.Departments = employeeRepository.GetDpart();
            ViewBag.Projects = employeeRepository.Getpro(); 
            return View(new Employee()); 
        }


        [HttpPost]
        public IActionResult Create(Employee employee, int[] projectIds)
        {

           employeeRepository.save(employee);

            employeeRepository.SavePro(employee , projectIds);

            return RedirectToAction("Index");

        }

        [HttpGet]
        public IActionResult AddProject(int id)
        {
            var employee = employeeRepository.FindProject(id);
            ViewBag.Departments =employeeRepository.GetDpart();
            ViewBag.Projects = employeeRepository.Getpro();
            return View(employee);
        }


        [HttpPost]
        public IActionResult AddProject(int id, int[] ProjectIds)
        {
            var employee= employeeRepository.FindProject(id);
            var emp = employeeRepository.FindProject(id);

            employeeRepository.RemovePro(emp, ProjectIds);

            if (emp != null)
            employeeRepository.SavePro(employee, ProjectIds);

            return RedirectToAction("Index");

        }
        

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var employee = employeeRepository.FindProject(id);
            ViewBag.Departments = employeeRepository.GetDpart();
            ViewBag.Projects = employeeRepository.Getpro();
            return View(employee);
        }

        [HttpPost]
        public IActionResult Edit(Employee employee, int[] ProjectIds)
        {

            employeeRepository.update(employee);
            var emp = employeeRepository.FindProject(employee.Id);

            employeeRepository.RemovePro(emp, ProjectIds);

            if (emp != null)
              employeeRepository.SavePro(employee, ProjectIds);

            return RedirectToAction("Index");
           
        }

        
        [HttpGet]
        public IActionResult Delete(int id)
        {
           employeeRepository.Delete(id);
            return RedirectToAction("Index");
        }


    }
}
