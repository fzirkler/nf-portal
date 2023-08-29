using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using NF_Portal.Data;
using NF_Portal.Models;

namespace NF_Portal.Pages.Programm
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
        public NF_Portal.Models.Programm Programm { get; set; } = default!;
        

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            Programm.Veranstaltungen = new Collection<NF_Portal.Models.Veranstaltung>();
          
          if (!ModelState.IsValid || _context.Programme == null || Programm == null)
            {
                return Page();
            }

            _context.Programme.Add(Programm);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
