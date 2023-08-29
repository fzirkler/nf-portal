using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using NF_Portal.Data;
using NF_Portal.Models;

namespace NF_Portal.Pages.Programm
{
    public class DeleteModel : PageModel
    {
        private readonly NF_Portal.Data.NfContext _context;

        public DeleteModel(NF_Portal.Data.NfContext context)
        {
            _context = context;
        }

        [BindProperty]
      public NF_Portal.Models.Programm Programm { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Programme == null)
            {
                return NotFound();
            }

            var programm = await _context.Programme.FirstOrDefaultAsync(m => m.Id == id);

            if (programm == null)
            {
                return NotFound();
            }
            else 
            {
                Programm = programm;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null || _context.Programme == null)
            {
                return NotFound();
            }
            var programm = await _context.Programme.FindAsync(id);

            if (programm != null)
            {
                Programm = programm;
                _context.Programme.Remove(Programm);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
