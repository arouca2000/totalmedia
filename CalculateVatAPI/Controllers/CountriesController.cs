using CalculateVatAPI.Context;
using CalculateVatAPI.DTOs.Response;
using CalculateVatAPI.Services.Interfaces;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics.Contracts;

namespace CalculateVatAPI.Controllers
{
    [Route("api/[Controller]/[Action]")]
    [ApiController]
    public class CountriesController : ControllerBase
    {
        private readonly ICountriesService _cs;

        public CountriesController(ICountriesService cs)
        {
            _cs = cs;
        }

        [HttpGet]
        public ActionResult<List<CountryResponse>> GetCountries()
        {
            try
            {
                var countries = _cs.GetCountries();
                if (!countries.Any())
                {
                    return NotFound("Countries not found!");
                }
                return Ok(countries);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

    }
}
