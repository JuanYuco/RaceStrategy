using RaceStrategy.Application.DTOs.Tire;

namespace RaceStrategy.Application.Interfaces
{
    public interface ITireService
    {
        Task<TireCollectionResponseDTO> GetAll(TireRequestDTO request);
    }
}
