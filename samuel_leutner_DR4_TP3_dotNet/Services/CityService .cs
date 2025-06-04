using Microsoft.EntityFrameworkCore;
using samuel_leutner_DR4_TP3_dotNet.data;
using samuel_leutner_DR4_TP3_dotNet.Models;

namespace samuel_leutner_DR4_TP3_dotNet.Services
{
    public class CityService : ICityService
    {
        private readonly CityBreaksContext _context;
        public CityService(CityBreaksContext context)
        {
            _context = context;
        }

        public async Task<List<City>> GetAllAsync()
        {
            return await _context.Cities
                .Include(c => c.Country)
                .Include(c => c.Properties)
                .Where(c => c.Properties.Any(p => p.DeletedAt == null))
                .OrderBy(c => c.Name)
                .ToListAsync();
        }

        public async Task<City?> GetByNameAsync(string name)
        {
            return await _context.Cities
                .Include(c => c.Country)
                .Include(c => c.Properties.Where(p => p.DeletedAt == null))
                .Where(c => EF.Functions.Collate(c.Name, "NOCASE") == EF.Functions.Collate(name, "NOCASE"))
                .FirstOrDefaultAsync();
        }
    }
}
