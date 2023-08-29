using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using NF_Portal.Data;
using NF_Portal.Models;

namespace NF_Portal.Pages.Veranstaltung
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
        public NF_Portal.Models.Veranstaltung Veranstaltung { get; set; } = default!;
        

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            
           var param = Request.Query["programm"];
            if(param != string.Empty)
                Veranstaltung.ProgrammId = int.Parse(param);
            
          if (!ModelState.IsValid || _context.Veranstaltungen == null || Veranstaltung == null)
            {
                return Page();
            }

            _context.Veranstaltungen.Add(Veranstaltung);
            await _context.SaveChangesAsync();

            ;
            return RedirectToPage("../Programm/Details", new Dictionary<string, string> { { "id", param } });

            //return RedirectToPage("./Index");
        }
    }
}
