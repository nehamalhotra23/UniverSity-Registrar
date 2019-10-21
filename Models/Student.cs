using System.Collections.Generic;

namespace University.Models
{
    public class Student
    {
        public Student()
        {
            this.Courses = new HashSet<CourseStudent>();
             this.Departments = new HashSet<DepartmentStudent>();

        }

        public int StudentId { get; set; }
        public string Name { get; set; }

        public ICollection<CourseStudent> Courses { get;}
        public ICollection<DepartmentStudent> Departments { get;}
    }
}