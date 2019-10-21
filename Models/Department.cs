using System.Collections.Generic;

namespace University.Models
{
  public class Department
    {
        public Department()
        {
            this.Departments = new HashSet<CourseStudent>();
        }

        public int DepartmentId { get; set; }

        public int CourseId { get; set; }
        public string DepartmentName { get; set; }
        public  ICollection<CourseStudent> Departments { get; set; }
    }
}