using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using CabinetVeterinar.Data;
using CabinetVeterinar.Models;

namespace CabinetVeterinar.Pages.Cabinets
{
    public class IndexModel : PageModel
    {
        private readonly CabinetVeterinarContext _context;

        public IndexModel(CabinetVeterinarContext context)
        {
            _context = context;
        }

        public IList<Cabinet> Cabinet { get; set; } = default!;
        public CabinetData CabinetD { get; set; }
        public int CabinetID { get; set; }

        public async Task OnGetAsync(int? id)
        {
            CabinetD = new CabinetData();

            CabinetD.Cabinets = await _context.Cabinet
                .Include(c => c.Vet)
                .Include(c => c.Animal)
                .Include(c => c.CabinetTypes)
                    .ThenInclude(ct => ct.EmergencyType)
                .AsNoTracking()
                .OrderBy(c => c.CabinetName)
                .ToListAsync();
        }

        public IActionResult OnPostShowVetAnimals(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            return RedirectToPage("/Cabinets/ShowVetAnimals", new { id });
        }
    }
}