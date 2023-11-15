using System.Collections.Generic;
using System.Threading.Tasks;
using CabinetVeterinar.Data;
using CabinetVeterinar.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace CabinetVeterinar.Pages.Cabinets
{
    public class ShowVetAnimalsModel : PageModel
    {
        private readonly CabinetVeterinarContext _context;

        public ShowVetAnimalsModel(CabinetVeterinarContext context)
        {
            _context = context;
        }

        public int VetId { get; set; }
        public Vet Vet { get; set; }
        public IList<Animal> Animals { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            VetId = id.Value;

            Vet = await _context.Vet.FirstOrDefaultAsync(m => m.Id == VetId);

            if (Vet == null)
            {
                return NotFound();
            }

            Animals = await _context.Cabinet
                .Include(c => c.Animal)
                .Where(c => c.VetID == VetId)
                .Select(c => c.Animal)
                .ToListAsync();

            return Page();
        }
    }
}