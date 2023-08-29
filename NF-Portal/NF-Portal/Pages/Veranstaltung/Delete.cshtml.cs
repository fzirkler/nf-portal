using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using NF_Portal.Data;
using NF_Portal.Models;

namespace NF_Portal.Pages.Veranstaltung
{
    public class DeleteModel : PageModel
    {
        private readonly NF_Portal.Data.NfContext _context;

        public DeleteModel(NF_Portal.Data.NfContext context)
        {
            _context = context;
        }

        [BindProperty]
      public NF_Portal.Models.Veranstaltung Veranstaltung { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Veranstaltungen == null)
            {
                return NotFound();
            }

            var veranstaltung = await _context.Veranstaltungen.FirstOrDefaultAsync(m => m.Id == id);

            if (veranstaltung == null)
            {
                return NotFound();
            }
            else 
            {
                Veranstaltung = veranstaltung;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null || _context.Veranstaltungen == null)
            {
                return NotFound();
            }
            var veranstaltung = await _context.Veranstaltungen.FindAsync(id);

            if (veranstaltung != null)
            {
                Veranstaltung = veranstaltung;
                _context.Veranstaltungen.Remove(Veranstaltung);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
