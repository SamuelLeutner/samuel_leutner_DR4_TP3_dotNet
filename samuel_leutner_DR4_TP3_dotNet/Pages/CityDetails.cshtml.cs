using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using samuel_leutner_DR4_TP3_dotNet.Models;
using samuel_leutner_DR4_TP3_dotNet.Services;

namespace samuel_leutner_DR4_TP3_dotNet.Pages
{
    public class CityDetailsModel : PageModel
    {
        private readonly ICityService _cityService;
        private readonly IPropertyService _propertyService;

        public CityDetailsModel(ICityService cityService, IPropertyService propertyService)
        {
            _cityService = cityService;
            _propertyService = propertyService;
        }

        public City? City { get; set; }

        [BindProperty(SupportsGet = true)]
        public string? PropertyNameFilter { get; set; }

        [BindProperty(SupportsGet = true)]
        public decimal? MinPriceFilter { get; set; }

        [BindProperty(SupportsGet = true)]
        public decimal? MaxPriceFilter { get; set; }


        public async Task<IActionResult> OnGetAsync(string name)
        {
            if (string.IsNullOrEmpty(name))
            {
                return NotFound();
            }

            City = await _cityService.GetByNameAsync(name);

            if (City == null)
            {
                return NotFound();
            }

            return Page();
        }

        public async Task<IActionResult> OnPostDeletePropertyAsync(int id, string cityName)
        {
            await _propertyService.DeleteAsync(id);

            return RedirectToPage("./CityDetails", new { name = cityName });
        }
    }
}
