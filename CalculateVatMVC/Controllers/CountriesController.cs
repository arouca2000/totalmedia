using CalculateVatMVC.Models;
using CalculateVatMVC.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace CalculateVatMVC.Controllers
{
    public class CountriesController : Controller
    {
        private readonly ICountriesService _countriesService;

        public CountriesController(ICountriesService countriesService)
        {
            _countriesService = countriesService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<CountryViewModel>>> Index()
        {
            var result = await _countriesService.GetCountries();

            if (result == null)
            {
                return View("Error");
            }
            return View(result);
        }
    }
}
