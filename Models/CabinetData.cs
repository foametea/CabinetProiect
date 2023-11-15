namespace CabinetVeterinar.Models
{
    public class CabinetData
    {
        public IEnumerable<Cabinet> Cabinets { get; set; }
        public IEnumerable<EmergencyType> CEmergencyTypes { get; set; }
        public IEnumerable<CabinetTypes> CabinetEmergencyTypes { get; set; }
    }
}
