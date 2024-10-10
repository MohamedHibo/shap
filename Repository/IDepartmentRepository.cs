using shap.Models;

namespace shap.Repository
{
    public interface IDepartmentRepository
    {
        void Delete(int id);
        Department Find(int id);
        Project FindPro(int id);
        List<Department> GetAll();
        List<string> pro(List<Department> dept);
        void Save(Department department);
        void Update(Department department);
    }
}