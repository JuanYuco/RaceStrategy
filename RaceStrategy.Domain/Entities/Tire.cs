namespace RaceStrategy.Domain.Entities
{
    public class Tire
    {
        public int Id { get; set; }
        public string Type { get; set; }
        public int EstimatedLaps { get; set; }
        public decimal ConsumedPerLap { get; set; }
        public int Performance { get; set; }

        public ICollection<TireByStrategy> TireByStrategies { get; set; }
    }
}
