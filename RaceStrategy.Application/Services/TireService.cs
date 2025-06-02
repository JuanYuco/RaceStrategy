using RaceStrategy.Application.DTOs.Tire;
using RaceStrategy.Application.Interfaces;
using RaceStrategy.Domain.Ports;

namespace RaceStrategy.Application.Services
{
    public class TireService : ITireService
    {
        private readonly ITireRepository _tireRepository;

        public TireService(ITireRepository tireRepository)
        {
            this._tireRepository = tireRepository;
        }

        /// <summary>
        /// Método que consulta los neumaticos en BD utilizando el respositorio
        /// </summary>
        /// <param name="request">el request viene vacío en este caso</param>
        public async Task<TireCollectionResponseDTO> GetAll(TireRequestDTO request)
        {
            var result = new TireCollectionResponseDTO() { Successful = false };
            try
            {
                List<TireDTO> tireDTOCollection = new List<TireDTO>();
                var tireCollection = await _tireRepository.GetAll();
                if (tireCollection != null && tireCollection.Count > 0)
                {
                    foreach (var tire in tireCollection)
                    {
                        tireDTOCollection.Add(new TireDTO()
                        {
                            Id = tire.Id,
                            Type = tire.Type,
                            ConsumedPerLap = tire.ConsumedPerLap,
                            EstimatedLaps = tire.EstimatedLaps,
                            Performance = tire.Performance
                        });
                    }
                }

                result.EntityCollection = tireDTOCollection;
                result.Successful = true;
            }
            catch (Exception ex)
            {
                result.UserMessage = "Ocurrió un error consultando los neumaticos, por favor intente más tarde.";
                result.InternalErrorMessage = ex.Message;
                result.HttpCode = 500;
            }

            return result;
        }
    }
}
