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

namespace NF_Portal.Pages.NfEvents
{
    public class EditModel : PageModel
    {
        private readonly NF_Portal.Data.NfContext _context;

        public EditModel(NF_Portal.Data.NfContext context)
        {
            _context = context;
        }

        [BindProperty]
        public NfEvent NfEvent { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.NfEvent == null)
            {
                return NotFound();
            }

            var nfevent =  await _context.NfEvent.FirstOrDefaultAsync(m => m.Id == id);
            if (nfevent == null)
            {
                return NotFound();
            }
            NfEvent = nfevent;
           ViewData["NfProgramId"] = new SelectList(_context.NfPrograms, "Id", "Id");
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

            _context.Attach(NfEvent).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!NfEventExists(NfEvent.Id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("../NfPrograms/Details", new Dictionary<string, string> { { "id", NfEvent.NfProgramId.ToString() } });
        }

        private bool NfEventExists(int id)
        {
          return (_context.NfEvent?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
