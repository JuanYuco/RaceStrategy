namespace RaceStrategy.Domain.Entities
{
    public class Driver
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int TeamId { get; set; }
        public int NationalityId { get; set; }

        public Team Team { get; set; }
        public Nationality Nationality { get; set; }
        public ICollection<Strategy> Strategies { get; set; }
    }
}
