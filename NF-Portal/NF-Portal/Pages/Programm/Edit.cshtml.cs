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

namespace NF_Portal.Pages.Programm
{
    public class EditModel : PageModel
    {
        private readonly NF_Portal.Data.NfContext _context;

        public EditModel(NF_Portal.Data.NfContext context)
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

            var programm =  await _context.Programme.FirstOrDefaultAsync(m => m.Id == id);
            if (programm == null)
            {
                return NotFound();
            }
            Programm = programm;
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

            _context.Attach(Programm).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProgrammExists(Programm.Id))
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

        private bool ProgrammExists(int id)
        {
          return (_context.Programme?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
