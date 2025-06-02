namespace RaceStrategy.Domain.Entities
{
    public class Strategy
    {
        public int Id { get; set; }
        public int DriverId { get; set; }
        public DateTime Date { get; set; }
        public int TotalLaps { get; set; }
        public string CreatedBy { get; set; }

        public Driver Driver { get; set; }
        public ICollection<TireByStrategy> TireByStrategies { get; set; }
    }
}
