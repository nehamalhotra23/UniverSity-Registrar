using System.Collections.Generic;

namespace University.Models
{
  public class Department
    {
        public Department()
        {
            this.Students = new HashSet<DepartmentStudent>();
            
        }

        public int DepartmentId { get; set; }

        public int CourseId { get; set; }
        public string DepartmentName { get; set; }
        public  ICollection<DepartmentStudent> Students { get; set; }
       
    }
    }
