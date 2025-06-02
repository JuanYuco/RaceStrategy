using Microsoft.EntityFrameworkCore;
using RaceStrategy.Domain.Entities;
using RaceStrategy.Domain.Ports;

namespace RaceStrategy.Infrastructure.Persistence.Adapters
{
    public class DriverRepository : IDriverRepository
    {
        private readonly AppDbContext _context;

        public DriverRepository(AppDbContext context)
        {
            this._context = context;
        }
        public async Task<List<Driver>> GetAll()
        {
            return await _context.Drivers.ToListAsync();
        }
    }
}
