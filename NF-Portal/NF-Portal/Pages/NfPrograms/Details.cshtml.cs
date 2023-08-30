using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using NF_Portal.Data;
using NF_Portal.Models;

namespace NF_Portal.Pages.NfPrograms
{
    public class DetailsModel : PageModel
    {
        private readonly NF_Portal.Data.NfContext _context;

        public DetailsModel(NF_Portal.Data.NfContext context)
        {
            _context = context;
        }

      public NfProgram NfProgram { get; set; } = default!; 

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.NfPrograms == null)
            {
                return NotFound();
            }

            var nfprogram = await _context.NfPrograms.FirstOrDefaultAsync(m => m.Id == id);
            
            if (nfprogram == null)
            {
                return NotFound();
            }
            else 
            {
                
            }
            return Page();
        }
    }
}
