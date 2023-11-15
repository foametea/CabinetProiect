using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using CabinetVeterinar.Data;
using CabinetVeterinar.Models;

namespace CabinetVeterinar.Pages.Emergency
{
    public class EditModel : PageModel
    {
        private readonly CabinetVeterinar.Data.CabinetVeterinarContext _context;

        public EditModel(CabinetVeterinar.Data.CabinetVeterinarContext context)
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

            var emergencytype =  await _context.EmergencyType.FirstOrDefaultAsync(m => m.ID == id);
            if (emergencytype == null)
            {
                return NotFound();
            }
            EmergencyType = emergencytype;
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(EmergencyType).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EmergencyTypeExists(EmergencyType.ID))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool EmergencyTypeExists(int id)
        {
          return (_context.EmergencyType?.Any(e => e.ID == id)).GetValueOrDefault();
        }
    }
}
