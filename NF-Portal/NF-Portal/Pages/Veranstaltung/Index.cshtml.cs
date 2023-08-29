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
    public class IndexModel : PageModel
    {
        private readonly NF_Portal.Data.NfContext _context;

        public IndexModel(NF_Portal.Data.NfContext context)
        {
            _context = context;
        }

        public IList<NF_Portal.Models.Veranstaltung> Veranstaltung { get;set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.Veranstaltungen != null)
            {
                Veranstaltung = await _context.Veranstaltungen.ToListAsync();
            }
        }
    }
}
