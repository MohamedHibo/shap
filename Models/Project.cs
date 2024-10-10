namespace shap.Models
{
    public class Project
    {
        public int ProjectId { get; set; }
        public string Name { get; set; }
        public string Location{ get; set; }
        public string city { get; set; }
        public HashSet<Employee> Employees { get; set; }=new HashSet<Employee>();


        public int? DepartmentId { get; set; }
        public Department? Department { get; set; }
    }
}
