namespace RaceStrategy.Application.DTOs.Tire
{
    public class TireDTO
    {
        public int Id { get; set; }
        public string Type { get; set; }
        public int EstimatedLaps { get; set; }
        public decimal ConsumedPerLap { get; set; }
        public int Performance { get; set; }
    }
}
