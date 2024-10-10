using Microsoft.CodeAnalysis;
using Microsoft.EntityFrameworkCore;
using shap.context;
using shap.Models;
using Project = shap.Models.Project;

namespace shap.Repository
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly appContext context;
        public EmployeeRepository(appContext appContext)
        {
            context = appContext;
        }
        public List<Employee> GetAll()
        {
            return context.employees.ToList();
        }
        public List<Department> GetDpart()
        {
            return context.department.ToList();
        }
        public List<Project> Getpro()
        {
            return context.Projects.ToList();
        }
        public void save(Employee employee)
        {
            context.employees.Add(employee);
            context.SaveChanges();
        }
        public void update(Employee employee)
        {
            context.employees.Update(employee);
            context.SaveChanges();
        }
        public void SavePro(Employee employee, int[] projectIds)
        {
            if (projectIds != null)
            {
                foreach (var projectId in projectIds)
                {
                    var project = context.Projects.Find(projectId);
                    if (project != null)
                    {
                        project.Employees.Add(employee);
                    }
                }
                context.SaveChanges();
            }
        }
        public void RemovePro(Employee emp, int[] projectIds)
        {
            foreach (var project in emp.Projects.ToList())
            {
                if (!projectIds.Contains(project.ProjectId))
                {
                    emp.Projects.Remove(project);
                }
            }
        }


        public List<string> DepartmentNames(List<Employee> emp)
        {
            List<string> departmentNames = new List<string>();
            foreach (var item in emp)
            {
                var department = context.department.Find(item.DepartmentId);
                if (department != null)
                {
                    departmentNames.Add(department.Name);
                }

            }
            return departmentNames;
        }
        public string DepartmentName(Employee emp)
        {
            var department = context.department.Find(emp.DepartmentId);
            return department.Name;
        }
        public Employee FindById(int id)
        {
            return context.employees.FirstOrDefault(x => x.Id == id);
        }

        public List<Project> Proj(int id)
        {
            return context.Projects
                .Where(p => p.Employees.Any(e => e.Id == id)).ToList();
        }
        public Employee FindProject(int id)
        {
            return context.employees.Include(e => e.Projects).FirstOrDefault(e => e.Id == id);

        }
        public void Delete(int id)
        {
            var employee = context.employees.Find(id);
            context.employees.Remove(employee);
            context.SaveChanges();
        }


    }
}
