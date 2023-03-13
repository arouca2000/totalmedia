using CalculateVatMVC.Models;
using CalculateVatMVC.Services;
using CalculateVatMVC.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace CalculateVatMVC.Controllers
{
    public class CountriesVatsController : Controller
    {
        private readonly ICountriesService _countriesService;
        private readonly ICountriesVatsService _countriesVatsService;

        public CountriesVatsController(ICountriesVatsService countriesVatsService, ICountriesService countriesService)
        {
            _countriesVatsService = countriesVatsService;
            _countriesService = countriesService;   
        }

        [HttpGet("id:int")]
        public async Task<ActionResult<CountryVatViewModel>> Index(int id)
        {
            var country = _countriesService.GetCountries().Result.First(a => a.Id == id);
            var vats = await _countriesVatsService.GetVatsByCountryId(id);

            var result = new CountryVatNameViewModel();

            result.CountryId = country.Id;
            result.CountryName = country.Name;
            result.countriesVats = vats;

            if (result == null)
            {
                return View("Error");
            }
            return View(result);
        }
    }
}
