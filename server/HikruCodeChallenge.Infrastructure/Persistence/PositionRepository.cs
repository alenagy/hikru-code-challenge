using HikruCodeChallenge.Application.Interfaces;
using HikruCodeChallenge.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace HikruCodeChallenge.Infrastructure.Persistence
{
    public class PositionRepository : IPositionRepository
    {
        private readonly ApplicationDbContext _context;

        public PositionRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<Position>> GetAllAsync()
        {
            return await _context.Positions.ToListAsync();
        }

        public async Task<Position?> GetByIdAsync(Guid id)
        {
            return await _context.Positions.FindAsync(id);
        }

        public async Task<Guid> CreateAsync(Position position)
        {
            position.Id = Guid.NewGuid();
            _context.Positions.Add(position);
            await _context.SaveChangesAsync();
            return position.Id;
        }

        public async Task UpdateAsync(Position position)
        {
            _context.Positions.Update(position);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(Position position)
        {
            _context.Positions.Remove(position);
            await _context.SaveChangesAsync();
        }
    }
}
