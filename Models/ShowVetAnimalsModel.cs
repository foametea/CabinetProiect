namespace CabinetVeterinar.Models
{
    public class ShowVetAnimalsModel
    {
        public int Id { get; set; }
        public Vet Vet { get; set; }
        public IList<Animal> Animals { get; set; }
    }
}
