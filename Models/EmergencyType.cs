namespace CabinetVeterinar.Models
{
    public class EmergencyType
    {
        public int ID { get; set; }

        public string TypeOfUrgency { get; set; }

        public ICollection<CabinetTypes>? CabinetTypes { get; set; }
    }
}
