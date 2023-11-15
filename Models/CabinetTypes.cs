namespace CabinetVeterinar.Models
{
    public class CabinetTypes
    {
        public int ID { get; set; }
        public int CabinetID { get; set; }
        public Cabinet Cabinet { get; set; }
        public int EmergencyTypeId { get; set; }

        public EmergencyType EmergencyType { get; set; }


    }
}
