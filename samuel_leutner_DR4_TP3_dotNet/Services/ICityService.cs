using samuel_leutner_DR4_TP3_dotNet.Models;

namespace samuel_leutner_DR4_TP3_dotNet.Services
{
    public interface ICityService
    {
        Task<List<City>> GetAllAsync();
        Task<City?> GetByNameAsync(string name);
    }
}
