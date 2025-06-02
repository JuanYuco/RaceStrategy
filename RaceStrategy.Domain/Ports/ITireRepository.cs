using RaceStrategy.Domain.Entities;

namespace RaceStrategy.Domain.Ports
{
    public interface ITireRepository
    {
        Task<List<Tire>> GetAll();
    }
}
