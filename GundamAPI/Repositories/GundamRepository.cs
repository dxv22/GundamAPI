using GundamAPI.Interfaces;
using GundamAPI.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;

namespace GundamAPI.Repositories
{
    public class GundamRepository(GundamContext context) : IGundamRepository
    {
        private readonly GundamContext _context = context;

        public async Task<IEnumerable<Gundam>> GetAllGundamsAsync()
        {
            return await _context.Gundams.ToListAsync();
        }

        public async Task<Gundam?> GetGundamByIdAsync(int id)
        {
            return await _context.Gundams.FirstOrDefaultAsync(g => g.Id == id);
        }

        public async Task<Gundam> AddGundamAsync(Gundam gundam)
        {
            var entry = await _context.Gundams.AddAsync(gundam);
            await _context.SaveChangesAsync();

            return entry.Entity;
        }

        public async Task<bool> UpdateGundamAsync(Gundam gundam)
        {
            _context.Gundams.Update(gundam);
            var changes = await _context.SaveChangesAsync();

            return changes > 0;
        }

        public async Task<bool> DeleteGundamAsync(Gundam gundam)
        {
            _context.Gundams.Remove(gundam);
            var result = await _context.SaveChangesAsync();
            
            return result > 0;
        }
    }
}
