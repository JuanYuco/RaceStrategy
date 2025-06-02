using RaceStrategy.Application.DTOs.Strategy;
using RaceStrategy.Application.DTOs.Tire;
using RaceStrategy.Application.Interfaces;
using RaceStrategy.Domain.Ports;
using RaceStrategy.Domain.Entities;

namespace RaceStrategy.Application.Services
{
    public class StrategyService : IStrategyService
    {
        private readonly IStrategyRepository _strategyRepository;
        private readonly ITireService _tireService;

        public StrategyService(IStrategyRepository strategyRepository, ITireService tireService)
        {
            this._strategyRepository = strategyRepository;
            this._tireService = tireService;
        }
        public async Task<OptimalStrategyCollectionResponseDTO> GetOptimalCollection(OptimalStrategyRequestDTO request)
        {
            var result = new OptimalStrategyCollectionResponseDTO() { Successful = false };

            try
            {
                var tireCollectionResult = await _tireService.GetAll(new DTOs.Tire.TireRequestDTO());
                if (!tireCollectionResult.Successful)
                {
                    result.UserMessage = tireCollectionResult.UserMessage;
                    result.HttpCode = tireCollectionResult.HttpCode;
                    return result;
                }

                var tireCollection = tireCollectionResult.EntityCollection;
                List<List<TireDTO>> combinationResult = new List<List<TireDTO>>();
                GenerateCombination(request.MaxLaps, 0, tireCollection, new List<TireDTO>(), combinationResult);
                if (combinationResult.Count > 0)
                {
                    await SaveStrategies(combinationResult, request.DriverId, request.CreatedBy, request.MaxLaps);
                }

                result.EntityCollection = MapCombinations(combinationResult);
                result.Successful = true;
            } catch(Exception ex)
            {
                result.UserMessage = "Ocurrió un error generando las estrategías.";
                result.InternalErrorMessage = ex.Message;
                result.HttpCode = 500;
            }

            return result;
        }

        private void GenerateCombination(int maxLaps, int lapsAmount, ICollection<TireDTO> tireCollection, List<TireDTO> combinationCollection, List<List<TireDTO>> combinationsResult)
        {
            List<TireDTO> currentUsedTireCollection = new List<TireDTO>();
            foreach (var tire in tireCollection)
            {
                var currentLapsAmount = lapsAmount + tire.EstimatedLaps;
                if (currentLapsAmount > maxLaps)
                {
                    continue;
                }

                var newCombinationCollection = new List<TireDTO>(combinationCollection) { tire };
                if (currentLapsAmount > (maxLaps - (maxLaps * 0.2))){
                    combinationsResult.Add(newCombinationCollection);
                }

                var newTireCollection = tireCollection.Where(x => !currentUsedTireCollection.Contains(x)).ToList();
                GenerateCombination(maxLaps, currentLapsAmount, newTireCollection, newCombinationCollection, combinationsResult);
                currentUsedTireCollection.Add(tire);
            }
        }

        private async Task SaveStrategies(List<List<TireDTO>> combinationsResult, int driverId, string createdBy, int maxLaps)
        {
            List<Strategy> strategyCollection = new List<Strategy>();
            foreach (var combination in combinationsResult)
            {
                var strategy = new Strategy()
                {
                    CreatedBy = createdBy,
                    Date = DateTime.Now,
                    DriverId = driverId,
                    TotalLaps = maxLaps
                };

                List<TireByStrategy> tireByStrategies = new List<TireByStrategy>();
                foreach (var tire in combination)
                {
                    tireByStrategies.Add(new TireByStrategy
                    {
                        TireId = tire.Id,
                        Strategy = strategy
                    });
                }

                strategy.TireByStrategies = tireByStrategies;
                strategyCollection.Add(strategy);
            }

            await _strategyRepository.CreateCollection(strategyCollection);
        }

        private List<OptimalStrategyDTO> MapCombinations(List<List<TireDTO>> combinationsResult)
        {
            List<OptimalStrategyDTO> optimalStrategyCollection = new List<OptimalStrategyDTO>();
            foreach (var combination in combinationsResult)
            {
                var optimalStrategy = new OptimalStrategyDTO
                {
                    AveragePerformance = combination.Average(x => x.Performance),
                    TotalConsumed = combination.Sum(x => x.ConsumedPerLap * x.EstimatedLaps)
                };

                List<OptimalStrategyStintDTO> stintCollection = new List<OptimalStrategyStintDTO>();
                foreach (var tire in combination)
                {
                    stintCollection.Add(new OptimalStrategyStintDTO
                    {
                        TireType = tire.Type,
                        Laps = tire.EstimatedLaps
                    });
                }

                optimalStrategy.StintCollection = stintCollection;
                optimalStrategyCollection.Add(optimalStrategy);
            }

            // Se ordena por promedio de rendimiento y se prioriza la cantidad de stints ascendente
            return optimalStrategyCollection.OrderByDescending(x => x.AveragePerformance).OrderBy(x => x.StintCollection.Count).ToList();
        }
    }
}
