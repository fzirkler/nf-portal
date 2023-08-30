using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using NF_Portal.Data;
using NF_Portal.Models;

namespace NF_Portal.Pages.NfEvents
{
    public class DeleteModel : PageModel
    {
        private readonly NF_Portal.Data.NfContext _context;

        public DeleteModel(NF_Portal.Data.NfContext context)
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

            var nfevent = await _context.NfEvent.FirstOrDefaultAsync(m => m.Id == id);

            if (nfevent == null)
            {
                return NotFound();
            }
            else 
            {
                NfEvent = nfevent;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null || _context.NfEvent == null)
            {
                return NotFound();
            }
            var nfevent = await _context.NfEvent.FindAsync(id);

            if (nfevent != null)
            {
                NfEvent = nfevent;
                _context.NfEvent.Remove(NfEvent);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("../NfPrograms/Details", new Dictionary<string, string> { { "id", NfEvent.NfProgramId.ToString() } });
        }
    }
}
