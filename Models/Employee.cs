using System.ComponentModel.DataAnnotations.Schema;

namespace shap.Models
{
    public class Employee
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Salary { get; set; }
        //[NotMapped]
        public int[] ?ProjectIds { get; set; }
        public int DepartmentId { get; set; }  
        public Department Department { get; set; }

        public HashSet<Project> Projects { get; set; }=new HashSet<Project>();
    }
}
