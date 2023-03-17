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
    public class IndexModel : PageModel
    {
        private readonly RazorCourseDemo.Data.AppDbContext _context;

        public IndexModel(RazorCourseDemo.Data.AppDbContext context)
        {
            _context = context;
        }

        public IList<Student> Student { get;set; } = default!;
        //public bool KayitMumkun { get; set; }
        public async Task OnGetAsync()
        {
            ViewData["KayitMumkun"] = _context.Courses.Any( );

            //KayitMumkun = true;
            if (_context.Students != null)
            {
                Student = await _context.Students.ToListAsync();
            }
        }
    }
}
