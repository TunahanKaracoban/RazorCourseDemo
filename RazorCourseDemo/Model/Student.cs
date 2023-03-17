using System.ComponentModel.DataAnnotations;

namespace RazorCourseDemo.Model
{
    public class Student
    {
        public int Id { get; set; }
        [StringLength(20)]
        public string Name { get; set; }
        public Course Course { get; set; }


    }
}
