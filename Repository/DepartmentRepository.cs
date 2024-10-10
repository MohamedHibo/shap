using shap.context;
using shap.Models;

namespace shap.Repository
{
    public class DepartmentRepository : IDepartmentRepository
    {
        private readonly appContext context;
        public DepartmentRepository(appContext appContext)
        {
            context = appContext;
        }
        public List<Department> GetAll()
        {
            return context.department.ToList();
        }
        public List<string> pro(List<Department> dept)
        {
            List<string> ProjectNames = new List<string>();
            foreach (var item in dept)
            {
                var pro = context.Projects.Find(item.Id);
                if (pro != null)
                {
                    ProjectNames.Add(pro.Name);
                }

            }
            return ProjectNames;
        }
        public void Save(Department department)
        {
            context.department.Add(department);
            context.SaveChanges();
        }
        public Department Find(int id)
        {
            return context.department.Find(id);
        }
        public void Update(Department department)
        {
            context.department.Update(department);
            context.SaveChanges();
        }
        public Project FindPro(int id)
        {
            return context.Projects.Find(id);
        }
        public void Delete(int id)
        {
            var department = context.department.Find(id);
            context.department.Remove(department);
            context.SaveChanges();
        }

      
    }
}
