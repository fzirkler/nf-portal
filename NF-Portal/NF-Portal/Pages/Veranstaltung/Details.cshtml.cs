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
    public class DetailsModel : PageModel
    {
        private readonly NF_Portal.Data.NfContext _context;

        public DetailsModel(NF_Portal.Data.NfContext context)
        {
            _context = context;
        }

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
    }
}
