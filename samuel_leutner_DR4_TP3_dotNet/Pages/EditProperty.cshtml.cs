using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using samuel_leutner_DR4_TP3_dotNet.Models;
using samuel_leutner_DR4_TP3_dotNet.Services;

namespace samuel_leutner_DR4_TP3_dotNet.Pages
{
    public class EditPropertyModel : PageModel
    {
        private readonly IPropertyService _propertyService;
        private readonly ICityService _cityService;

        public EditPropertyModel(IPropertyService propertyService, ICityService cityService)
        {
            _propertyService = propertyService;
            _cityService = cityService;
        }

        [BindProperty]
        public Property Property { get; set; } = default!;

        public SelectList? Cities { get; set; }

        public async Task<IActionResult> OnGetAsync(int id)
        {
            Property = await _propertyService.GetByIdAsync(id) ?? default!;
            if (Property == null)
            {
                return NotFound();
            }
           
            var cityList = await _cityService.GetAllAsync();
            Cities = new SelectList(cityList, "Id", "Name");

            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int id)
        {
            var existingProperty = await _propertyService.GetByIdAsync(id);

            if (existingProperty == null)
            {
                return NotFound();
            }
           
            var success = await TryUpdateModelAsync(
                existingProperty,
                "Property",
                p => p.Name,
                p => p.PricePerNight,
                p => p.CityId);

            if (!success)
            {
                var cityList = await _cityService.GetAllAsync();
                Cities = new SelectList(cityList, "Id", "Name");
                return Page();
            }

            await _propertyService.UpdateAsync(existingProperty);

            return RedirectToPage("./CityDetails", new { name = existingProperty.City.Name });
        }
    }
}
