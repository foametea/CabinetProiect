using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using CabinetVeterinar.Data;
using CabinetVeterinar.Models;
using System.Security.Policy;
using Microsoft.AspNetCore.Authorization;

namespace CabinetVeterinar.Pages.Cabinets
{
    [Authorize(Roles = "Admin")]
    public class CreateModel : ModelForEmergency
    {
        private readonly CabinetVeterinar.Data.CabinetVeterinarContext _context;

        public CreateModel(CabinetVeterinar.Data.CabinetVeterinarContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {

            ViewData["AnimalID"] = new SelectList(_context.Set<Animal>(), "Id","Name");
            ViewData["VetID"] = new SelectList(_context.Set<Vet>(), "Id","Name");
            var cabinet = new Cabinet();
            cabinet.CabinetTypes = new List<CabinetTypes>();
            PopulateAssignedEmergencyTypesData(_context, cabinet);

            return Page();
        }

        [BindProperty]
        public Cabinet Cabinet { get; set; } = default!;


        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync(string[] selectedEmergencyTypes)
        {
            var newCabinet = new Cabinet();

            if (selectedEmergencyTypes != null)
            {
                newCabinet.CabinetTypes = new List<CabinetTypes>();

                foreach (var emergencyType in selectedEmergencyTypes)
                {
                    var emergencyTypeToAdd = new CabinetTypes
                    {
                        EmergencyTypeId = int.Parse(emergencyType)
                    };

                    newCabinet.CabinetTypes.Add(emergencyTypeToAdd);
                }
            }

            newCabinet.VetID = Cabinet.VetID;

            Cabinet.CabinetTypes = newCabinet.CabinetTypes;

            _context.Cabinet.Add(Cabinet);
            await _context.SaveChangesAsync();
            return RedirectToPage("./Index");
        }
    }
}
