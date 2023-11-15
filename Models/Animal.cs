using System.ComponentModel.DataAnnotations;

namespace CabinetVeterinar.Models
{
    public class Animal
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Name is required")]
        [StringLength(50, ErrorMessage = "Name must be less than 50 characters")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Species is required")]
        [StringLength(50, ErrorMessage = "Species must be less than 50 characters")]
        public string Species { get; set; }

        [Required(ErrorMessage = "Age is required")]
        [Range(0, int.MaxValue, ErrorMessage = "Age must be a positive number")]
        public int Age { get; set; }

        public ICollection<Cabinet>? Cabinets { get; set; }
    }
}
