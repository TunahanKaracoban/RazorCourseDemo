using System.ComponentModel.DataAnnotations;

namespace RazorCourseDemo.Model
{
    public class Course
    {
        public int Id { get; set; }
        [StringLength(20)]
        public string Title { get; set; }
        public int Credits { get; set; }
        public ICollection<Student> Students { get; set; }=new List<Student>();
        
    }
}
