using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using RazorCourseDemo.Data;
using RazorCourseDemo.Model;

namespace RazorCourseDemo.Pages.Students
{
    public class CreateModel : PageModel
    {
        private readonly RazorCourseDemo.Data.AppDbContext _context;

        public CreateModel(RazorCourseDemo.Data.AppDbContext context)
        {
            _context = context;
        }
        public List<SelectListItem> CourseListItems { get; set; }=new List<SelectListItem>();
        [BindProperty]
        public int SelectedCourseId { get; set; }
        public IActionResult OnGet()
        {
            var coursesFromDb = _context.Courses.ToList();
            foreach (var course in coursesFromDb)
            {
                CourseListItems.Add(new SelectListItem
                {
                    Value = course.Id.ToString(),
                    Text=course.Title
                });
            }
            return Page();
        }

        [BindProperty]
        public Student Student { get; set; } = default!;
        

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            if (_context.Students == null || Student == null)
            {
                return Page();
            }
            var courseSelectedFromDb = _context.Courses.Find(SelectedCourseId);

            if (courseSelectedFromDb != null)
            {
                Student.Course = courseSelectedFromDb;
                _context.Students.Add(Student);
                await _context.SaveChangesAsync();

                return RedirectToPage("./Index");
            }
            return Page();
        }
    }
}
