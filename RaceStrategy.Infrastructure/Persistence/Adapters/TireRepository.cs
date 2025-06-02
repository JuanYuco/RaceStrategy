using Microsoft.EntityFrameworkCore;
using RaceStrategy.Domain.Entities;
using RaceStrategy.Domain.Ports;

namespace RaceStrategy.Infrastructure.Persistence.Adapters
{
    public class TireRepository : ITireRepository
    {
        private readonly AppDbContext _context;

        public TireRepository(AppDbContext context)
        {
            this._context = context;
        }
        public async Task<List<Tire>> GetAll()
        {
            return await _context.Tires.ToListAsync();
        }
    }
}
