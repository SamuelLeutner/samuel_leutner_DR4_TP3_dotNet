using samuel_leutner_DR4_TP3_dotNet.Models;

namespace samuel_leutner_DR4_TP3_dotNet.Services
{
    public interface IPropertyService
    {
        Task AddAsync(Property property);
        Task<Property?> GetByIdAsync(int id);
        Task UpdateAsync(Property property);
        Task DeleteAsync(int id);
        Task<List<Property>> GetFilteredAsync(decimal? minPrice, decimal? maxPrice, string? cityName, string? propertyName);
    }
}
