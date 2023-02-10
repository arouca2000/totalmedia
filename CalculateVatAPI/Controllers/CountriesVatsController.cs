using CalculateVatAPI.DTOs.Response;
using CalculateVatAPI.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace CalculateVatAPI.Controllers
{
    [Route("api/[Controller]/[Action]")]
    [ApiController]
    public class CountriesVatsController : ControllerBase
    {
        private readonly ICountriesVatsService _cvs;

        public CountriesVatsController(ICountriesVatsService cvs)
        {
            _cvs = cvs;
        }

        [HttpGet("{countryId:int}")]
        public ActionResult<List<CountryVatResponse>> GetVatsByCountryId(int countryId)
        {
            try
            {
                var countriesVats = _cvs.GetVatsByCountryId(countryId);
                if (!countriesVats.Any())
                {
                    return NotFound($"Vats for country {countryId} not found!");
                }
                return Ok(countriesVats);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

    }
}
