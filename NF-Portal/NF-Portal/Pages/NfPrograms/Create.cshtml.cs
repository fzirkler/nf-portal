using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using NF_Portal.Data;
using NF_Portal.Models;

namespace NF_Portal.Pages.NfPrograms
{
    public class CreateModel : PageModel
    {
        private readonly NF_Portal.Data.NfContext _context;

        public CreateModel(NF_Portal.Data.NfContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public NfProgram NfProgram { get; set; } = default!;
        

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
          if (!ModelState.IsValid || _context.NfPrograms == null || NfProgram == null)
            {
                return Page();
            }

            _context.NfPrograms.Add(NfProgram);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
