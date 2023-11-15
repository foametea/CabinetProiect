using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using CabinetVeterinar.Data;
using CabinetVeterinar.Models;

namespace CabinetVeterinar.Pages.Cabinets
{
    public class DetailsModel : PageModel
    {
        private readonly CabinetVeterinar.Data.CabinetVeterinarContext _context;

        public DetailsModel(CabinetVeterinar.Data.CabinetVeterinarContext context)
        {
            _context = context;
        }

      public Cabinet Cabinet { get; set; } = default!; 

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Cabinet = await _context.Cabinet
                .Include(c => c.Animal)
                .Include(c => c.Vet)
                .Include(c => c.CabinetTypes)
                    .ThenInclude(ct => ct.EmergencyType)
                .AsNoTracking()
                .FirstOrDefaultAsync(m => m.CabinetId == id);

            if (Cabinet == null)
            {
                return NotFound();
            }

            return Page();
        }
    }
}
