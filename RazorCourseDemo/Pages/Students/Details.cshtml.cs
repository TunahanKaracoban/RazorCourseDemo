using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using RazorCourseDemo.Data;
using RazorCourseDemo.Model;

namespace RazorCourseDemo.Pages.Students
{
    public class DetailsModel : PageModel
    {
        private readonly RazorCourseDemo.Data.AppDbContext _context;

        public DetailsModel(RazorCourseDemo.Data.AppDbContext context)
        {
            _context = context;
        }

        public Student Student { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Students == null)
            {
                return NotFound();
            }

            var student = await _context
                .Students
                .Include(s => s.Course)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (student == null)
            {
                return NotFound();
            }
            else
            {
                Student = student;
            }
            return Page();
        }
    }
}
