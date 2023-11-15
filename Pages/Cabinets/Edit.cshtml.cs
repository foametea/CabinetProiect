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
using System.Security.Policy;
using Microsoft.AspNetCore.Authorization;

namespace CabinetVeterinar.Pages.Cabinets
{
    [Authorize(Roles = "Admin")]
    public class EditModel : ModelForEmergency
    {
        private readonly CabinetVeterinar.Data.CabinetVeterinarContext _context;

        public EditModel(CabinetVeterinar.Data.CabinetVeterinarContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Cabinet Cabinet { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cabinet = await _context.Cabinet
                .Include(c => c.Animal)
                .Include(c => c.Vet)
                .Include(c => c.CabinetTypes)
                    .ThenInclude(ct => ct.EmergencyType)
                .AsNoTracking()
                .FirstOrDefaultAsync(m => m.CabinetId == id);

            if (cabinet == null)
            {
                return NotFound();
            }

            PopulateAssignedEmergencyTypesData(_context, cabinet);
            Cabinet = cabinet;

            ViewData["AnimalID"] = new SelectList(_context.Set<Animal>(), "Id", "Name");
            ViewData["VetID"] = new SelectList(_context.Set<Vet>(), "Id", "Name");

            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync(int? id, string[] selectedEmergencyTypes)
        {
            if (id == null)
            {
                return NotFound();
            }

            // Include necessary related entities for Cabinet
            var cabinetToUpdate = await _context.Cabinet
                .Include(c => c.Animal)
                .Include(c => c.Vet)
                .Include(c => c.CabinetTypes)
                    .ThenInclude(ct => ct.EmergencyType)
                .FirstOrDefaultAsync(s => s.CabinetId == id);

            if (cabinetToUpdate == null)
            {
                return NotFound();
            }

            if (await TryUpdateModelAsync<Cabinet>(
                cabinetToUpdate,
                "Cabinet",
                c => c.CabinetName, c => c.AnimalID, c => c.VetID, c => c.Prescription))
            {
                UpdateCabinetEmergencyTypes(_context, selectedEmergencyTypes, cabinetToUpdate);

                await _context.SaveChangesAsync();
                return RedirectToPage("./Index");
            }

            UpdateCabinetEmergencyTypes(_context, selectedEmergencyTypes, cabinetToUpdate);
            PopulateAssignedEmergencyTypesData(_context, cabinetToUpdate);

            return Page();
        }
    }
    }

