namespace RaceStrategy.Domain.Entities
{
    public class TireByStrategy
    {
        public int Id { get; set; }
        public int TireId { get; set; }
        public int StrategyId { get; set; }

        public Tire Tire { get; set; }
        public Strategy Strategy { get; set; }
    }
}
