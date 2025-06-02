using RaceStrategy.Application.DTOs.Driver;

namespace RaceStrategy.Application.Interfaces
{
    public interface IDriverService
    {
        Task<DriverCollectionResponseDTO> GetAll(DriverRequestDTO request);
    }
}
