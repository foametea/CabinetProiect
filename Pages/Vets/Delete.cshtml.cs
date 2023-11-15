﻿using System;
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
    public class DeleteModel : PageModel
    {
        private readonly CabinetVeterinar.Data.CabinetVeterinarContext _context;

        public DeleteModel(CabinetVeterinar.Data.CabinetVeterinarContext context)
        {
            _context = context;
        }

        [BindProperty]
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

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null || _context.Vet == null)
            {
                return NotFound();
            }
            var vet = await _context.Vet.FindAsync(id);

            if (vet != null)
            {
                Vet = vet;
                _context.Vet.Remove(Vet);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
