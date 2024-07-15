using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using LabAssignment4.DataAccess;

namespace LabAssignment4.Pages.AcademicRecordManagement
{
    public class CreateModel : PageModel
    {
        private readonly LabAssignment4.DataAccess.StudentRecordContext _context;

        public CreateModel(LabAssignment4.DataAccess.StudentRecordContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
        ViewData["CourseCode"] = new SelectList(_context.Courses, "Code", "Code");
        ViewData["StudentId"] = new SelectList(_context.Students, "Id", "Id");
            return Page();
        }

        [BindProperty]
        public Academicrecord Academicrecord { get; set; } = default!;

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Academicrecords.Add(Academicrecord);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
