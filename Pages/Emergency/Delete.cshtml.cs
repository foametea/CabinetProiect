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
    public class DeleteModel : PageModel
    {
        private readonly CabinetVeterinar.Data.CabinetVeterinarContext _context;

        public DeleteModel(CabinetVeterinar.Data.CabinetVeterinarContext context)
        {
            _context = context;
        }

        [BindProperty]
      public EmergencyType EmergencyType { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.EmergencyType == null)
            {
                return NotFound();
            }

            var emergencytype = await _context.EmergencyType.FirstOrDefaultAsync(m => m.ID == id);

            if (emergencytype == null)
            {
                return NotFound();
            }
            else 
            {
                EmergencyType = emergencytype;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null || _context.EmergencyType == null)
            {
                return NotFound();
            }
            var emergencytype = await _context.EmergencyType.FindAsync(id);

            if (emergencytype != null)
            {
                EmergencyType = emergencytype;
                _context.EmergencyType.Remove(EmergencyType);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
