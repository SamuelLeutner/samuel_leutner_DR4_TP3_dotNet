using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using samuel_leutner_DR4_TP3_dotNet.Models;
using samuel_leutner_DR4_TP3_dotNet.Services;

namespace samuel_leutner_DR4_TP3_dotNet.Pages
{
    public class FilterPropertiesModel : PageModel
    {
        private readonly IPropertyService _propertyService;
        private readonly ICityService _cityService;
        public FilterPropertiesModel(IPropertyService propertyService, ICityService cityService)
        {
            _propertyService = propertyService;
            _cityService = cityService;
        }

        public IList<Property> Properties { get; set; } = new List<Property>();

        [BindProperty(SupportsGet = true)]
        public decimal? MinPriceFilter { get; set; }

        [BindProperty(SupportsGet = true)]
        public decimal? MaxPriceFilter { get; set; }

        [BindProperty(SupportsGet = true)]
        public string? CityNameFilter { get; set; }

        [BindProperty(SupportsGet = true)]
        public string? PropertyNameFilter { get; set; }

        public SelectList? Cities { get; set; }
        public async Task OnGetAsync()
        {
            var cityList = await _cityService.GetAllAsync();
            Cities = new SelectList(cityList, "Name", "Name");
            Properties = await _propertyService.GetFilteredAsync(
                MinPriceFilter,
                MaxPriceFilter,
                CityNameFilter,
                PropertyNameFilter
            );
        }
    }
}
