using RaceStrategy.Application.DTOs.Strategy;

namespace RaceStrategy.Application.Interfaces
{
    public interface IStrategyService
    {
        Task<OptimalStrategyCollectionResponseDTO> GetOptimalCollection(OptimalStrategyRequestDTO request);
    }
}
