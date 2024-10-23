using GundamAPI.Models;

namespace GundamAPI.Interfaces
{
    public interface IGundamRepository
    {
        Task<IEnumerable<Gundam>> GetAllGundamsAsync();
        Task<Gundam?> GetGundamByIdAsync(int id);
        Task<Gundam> AddGundamAsync(Gundam gundam);
        Task<bool> UpdateGundamAsync(Gundam gundam);
        Task<bool> DeleteGundamAsync(int id);
    }
}
