using shap.Models;

namespace shap.Repository
{
    public interface IEmployeeRepository
    {
        void Delete(int id);
        string DepartmentName(Employee emp);
        List<string> DepartmentNames(List<Employee> emp);
        Employee FindById(int id);
        Employee FindProject(int id);
        List<Employee> GetAll();
        List<Department> GetDpart();
        List<Project> Getpro();
        List<Project> Proj(int id);
        void RemovePro(Employee emp, int[] projectIds);
        void save(Employee employee);
        void SavePro(Employee employee, int[] projectIds);
        void update(Employee employee);
    }
}