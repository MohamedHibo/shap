using shap.context;
using shap.Models;

namespace shap.Repository
{
    public class ProjectRepository : IProjectRepository
    {
        appContext context;
        public ProjectRepository(appContext context)
        {
            this.context = context;
        }
        public List<Project> GetAll()
        {
            return context.Projects.ToList();
        }
        public List<Department> Depart()
        {
            return context.department.ToList();
        }
        public void Save(Project pro)
        {
            context.Projects.Add(pro);
            context.SaveChanges();
        }
        public Project Find(int id)
        {
            return context.Projects.Find(id);
        }
        public void Update(Project pro)
        {
            context.Projects.Update(pro);
            context.SaveChanges();
        }
        public void Delete(int id)
        {
            var pro = context.Projects.Find(id);
            context.Remove(pro);
            context.SaveChanges();
        }
    }
}
