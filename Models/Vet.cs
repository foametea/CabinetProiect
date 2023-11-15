using System.ComponentModel.DataAnnotations;

namespace CabinetVeterinar.Models
{
    public class Vet
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Name is required.")]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "Name must be between 3 and 50 characters.")]
        public string Name { get; set; }

        [Range(0, 100, ErrorMessage = "ExperienceYears must be between 0 and 100.")]
        public int ExperienceYears { get; set; }

        public ICollection<Cabinet>? Cabinets { get; set; }
    }
}
