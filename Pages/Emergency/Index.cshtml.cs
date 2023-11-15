using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using CabinetVeterinar.Data;
using CabinetVeterinar.Models;

namespace CabinetVeterinar.Pages.Emergency
{
    public class IndexModel : PageModel
    {
        private readonly CabinetVeterinar.Data.CabinetVeterinarContext _context;

        public IndexModel(CabinetVeterinar.Data.CabinetVeterinarContext context)
        {
            _context = context;
        }

        public IList<EmergencyType> EmergencyType { get;set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.EmergencyType != null)
            {
                EmergencyType = await _context.EmergencyType.ToListAsync();
            }
        }
    }
}
