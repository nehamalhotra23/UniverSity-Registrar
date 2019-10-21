using System.Collections.Generic;

namespace University.Models
{
  public class Course
    {
        public Course()
        {
            this.Students = new HashSet<CourseStudent>();
        }

        public int CourseId { get; set; }
        public string Name { get; set; }
        public  ICollection<CourseStudent> Students { get; set; }
    }
}