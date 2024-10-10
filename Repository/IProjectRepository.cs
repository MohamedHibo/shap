using shap.Models;

namespace shap.Repository
{
    public interface IProjectRepository
    {
        void Delete(int id);
        List<Department> Depart();
        Project Find(int id);
        List<Project> GetAll();
        void Save(Project pro);
        void Update(Project pro);
    }
}