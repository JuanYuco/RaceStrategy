namespace RaceStrategy.Application.DTOs.Strategy
{
    public class OptimalStrategyDTO
    {
        public decimal TotalConsumed { get; set; }
        public double AveragePerformance { get; set; }
        public List<OptimalStrategyStintDTO> StintCollection { get; set; }

    }

    public class OptimalStrategyStintDTO
    {
        public string TireType { get; set; }
        public int Laps { get; set; }
    }
}
