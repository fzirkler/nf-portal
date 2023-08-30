using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using NF_Portal.Data;
using NF_Portal.Models;

namespace NF_Portal.Pages.NfEvents
{
    public class CreateModel : PageModel
    {
        private readonly NF_Portal.Data.NfContext _context;

        public CreateModel(NF_Portal.Data.NfContext context)
        {
            _context = context;
        }

        public IActionResult OnGet(int? programId)
        {
        ViewData["NfProgramId"] = new SelectList(_context.NfPrograms, "Id", "Id");
           

            if (programId == null)
                return NotFound();

            NfEvent = new NfEvent();
            NfEvent.NfProgramId = programId.Value;
            return Page();
        }

        [BindProperty]
        public NfEvent NfEvent { get; set; } = default!;
        

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
          if (!ModelState.IsValid || _context.NfEvent == null || NfEvent == null)
            {
                return Page();
            }
          
            _context.NfEvent.Add(NfEvent);
            await _context.SaveChangesAsync();

            return RedirectToPage("../NfPrograms/Details", new Dictionary<string, string> { { "id", NfEvent.NfProgramId.ToString() } });
        }
    }
}
