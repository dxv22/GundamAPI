using GundamAPI.Models;

namespace GundamAPI.Interfaces
{
    public interface IGundamRepository
    {
        Task<IEnumerable<Gundam>> GetAllGundamsAsync();
        Task<Gundam?> GetGundamByIdAsync(int id);
        Task<Gundam> AddGundamAsync(GundamDto gundam);
        Task<bool> UpdateGundamAsync(GundamDto gundam);
        Task<bool> DeleteGundamAsync(int id);
    }
}
