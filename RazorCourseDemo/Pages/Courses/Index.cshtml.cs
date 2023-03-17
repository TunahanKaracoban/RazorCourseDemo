using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using RazorCourseDemo.Data;
using RazorCourseDemo.Model;

namespace RazorCourseDemo.Pages.Courses
{
    public class IndexModel : PageModel
    {
        private readonly RazorCourseDemo.Data.AppDbContext _context;

        public IndexModel(RazorCourseDemo.Data.AppDbContext context)
        {
            _context = context;
        }

        public IList<Course> Course { get;set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.Courses != null)
            {
                Course = await _context.Courses.ToListAsync();
            }
        }
    }
}
