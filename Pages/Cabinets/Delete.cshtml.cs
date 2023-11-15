using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using CabinetVeterinar.Data;
using CabinetVeterinar.Models;
using Microsoft.AspNetCore.Authorization;

namespace CabinetVeterinar.Pages.Cabinets
{
    [Authorize(Roles = "Admin")]
    public class DeleteModel : PageModel
    {
        private readonly CabinetVeterinar.Data.CabinetVeterinarContext _context;

        public DeleteModel(CabinetVeterinar.Data.CabinetVeterinarContext context)
        {
            _context = context;
        }

        [BindProperty]
      public Cabinet Cabinet { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Cabinet == null)
            {
                return NotFound();
            }

            var cabinet = await _context.Cabinet.Include(c => c.Animal).FirstOrDefaultAsync(m => m.CabinetId == id);

            if (cabinet == null)
            {
                return NotFound();
            }
            else 
            {
                Cabinet = cabinet;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null || _context.Cabinet == null)
            {
                return NotFound();
            }
            var cabinet = await _context.Cabinet.FindAsync(id);

            if (cabinet != null)
            {
                Cabinet = cabinet;
                _context.Cabinet.Remove(Cabinet);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
