using RaceStrategy.Domain.Entities;
using RaceStrategy.Domain.Ports;

namespace RaceStrategy.Infrastructure.Persistence.Adapters
{
    public class StrategyRepository : IStrategyRepository
    {
        private readonly AppDbContext _context;

        public StrategyRepository(AppDbContext context)
        {
            this._context = context;
        }
        public async Task CreateCollection(List<Strategy> strategyCollection)
        {
            await _context.Strategies.AddRangeAsync(strategyCollection);
            await _context.SaveChangesAsync();
        }
    }
}
