using HikruCodeChallenge.Domain.Entities;

namespace HikruCodeChallenge.Application.Interfaces
{
    public interface IPositionRepository
    {
        Task<List<Position>> GetAllAsync();
        Task<Position?> GetByIdAsync(Guid id);
        Task<Guid> CreateAsync(Position position);
        Task UpdateAsync(Position position);
        Task DeleteAsync(Position position);
    }
}
