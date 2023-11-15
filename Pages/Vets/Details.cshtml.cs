using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using CabinetVeterinar.Data;
using CabinetVeterinar.Models;

namespace CabinetVeterinar.Pages.Vets
{
    public class DetailsModel : PageModel
    {
        private readonly CabinetVeterinar.Data.CabinetVeterinarContext _context;

        public DetailsModel(CabinetVeterinar.Data.CabinetVeterinarContext context)
        {
            _context = context;
        }

      public Vet Vet { get; set; } = default!; 

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Vet == null)
            {
                return NotFound();
            }

            var vet = await _context.Vet.FirstOrDefaultAsync(m => m.Id == id);
            if (vet == null)
            {
                return NotFound();
            }
            else 
            {
                Vet = vet;
            }
            return Page();
        }
    }
}
