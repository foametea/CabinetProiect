using System.ComponentModel.DataAnnotations;
using System.Security.Policy;

namespace CabinetVeterinar.Models
{
    public class Cabinet
    {
        public int CabinetId { get; set; }
        [Required(ErrorMessage = "CabinetName is required.")]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "CabinetName must be between 3 and 50 characters.")]
        public string CabinetName { get; set; }

        [Range(1, int.MaxValue, ErrorMessage = "Please select a valid Animal.")]
        public int? AnimalID { get; set; }
        public Animal? Animal { get; set; }

        [StringLength(1000, ErrorMessage = "Prescription cannot exceed 1000 characters.")]
        public string Prescription { get; set; }

        [Range(1, int.MaxValue, ErrorMessage = "Please select a valid Vet.")]
        public int? VetID { get; set; }
        public Vet? Vet { get; set; }

        public ICollection<CabinetTypes>? CabinetTypes { get; set; }
    }
}
