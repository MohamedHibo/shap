namespace shap.Models
{
    public class Department
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string shap {  get; set; }
        public HashSet<Employee> Employees { get; set; }=new HashSet<Employee>();
        public HashSet<Project> Projects { get; set; }= new HashSet<Project>();
    }
}
