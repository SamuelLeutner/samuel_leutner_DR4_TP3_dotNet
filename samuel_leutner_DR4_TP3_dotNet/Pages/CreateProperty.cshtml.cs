using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using samuel_leutner_DR4_TP3_dotNet.Models;
using samuel_leutner_DR4_TP3_dotNet.Services;

namespace samuel_leutner_DR4_TP3_dotNet.Pages
{
    public class CreatePropertyModel : PageModel
    {
        private readonly ICityService _cityService;
        private readonly IPropertyService _propertyService;

        public CreatePropertyModel(ICityService cityService, IPropertyService propertyService)
        {
            _cityService = cityService;
            _propertyService = propertyService;
        }

        [BindProperty]
        public Property Property { get; set; } = default!;

        public SelectList? Cities { get; set; }

        public async Task<IActionResult> OnGetAsync(int? cityId)
        {
            var cityList = await _cityService.GetAllAsync();
            Cities = new SelectList(cityList, "Id", "Name");

            if (cityId.HasValue)
            {
                Property = new Property { CityId = cityId.Value };
            }

            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                var cityList = await _cityService.GetAllAsync();
                Cities = new SelectList(cityList, "Id", "Name");
                return Page();
            }

            await _propertyService.AddAsync(Property);

            return RedirectToPage("./CityDetails", new { name = Property.City.Name });
        }
    }
}
