using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using LabAssignment4.DataAccess;

namespace LabAssignment4.Pages.AcademicRecordManagement
{
    public class IndexModel : PageModel
    {
        private readonly LabAssignment4.DataAccess.StudentRecordContext _context;

        public IndexModel(LabAssignment4.DataAccess.StudentRecordContext context)
        {
            _context = context;
        }

        public IList<Academicrecord> Academicrecord { get;set; } = default!;

        public async Task OnGetAsync()
        {
            Academicrecord = await _context.Academicrecords
                .Include(a => a.CourseCodeNavigation)
                .Include(a => a.Student).ToListAsync();
        }
    }
}
