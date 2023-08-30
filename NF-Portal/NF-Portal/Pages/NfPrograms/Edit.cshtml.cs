using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using NF_Portal.Data;
using NF_Portal.Models;

namespace NF_Portal.Pages.NfPrograms
{
    public class EditModel : PageModel
    {
        private readonly NF_Portal.Data.NfContext _context;

        public EditModel(NF_Portal.Data.NfContext context)
        {
            _context = context;
        }

        [BindProperty]
        public NfProgram NfProgram { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.NfPrograms == null)
            {
                return NotFound();
            }

            var nfprogram =  await _context.NfPrograms.FirstOrDefaultAsync(m => m.Id == id);
            if (nfprogram == null)
            {
                return NotFound();
            }
            NfProgram = nfprogram;
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(NfProgram).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!NfProgramExists(NfProgram.Id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool NfProgramExists(int id)
        {
          return (_context.NfPrograms?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
