using RaceStrategy.Domain.Entities;

namespace RaceStrategy.Domain.Ports
{
    public interface IStrategyRepository
    {
        Task CreateCollection(List<Strategy> strategyCollection);
    }
}
