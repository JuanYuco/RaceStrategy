using RaceStrategy.Domain.Entities;

namespace RaceStrategy.Domain.Ports
{
    public interface IDriverRepository
    {
        Task<List<Driver>> GetAll();
    }
}
