namespace RaceStrategy.Domain.Entities
{
    public class Nationality
    {
        public int Id { get; set; }
        public string Description { get; set; }

        public ICollection<Driver> Drivers { get; set; }
    }
}
