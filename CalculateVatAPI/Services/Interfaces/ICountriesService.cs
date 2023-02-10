using CalculateVatAPI.DTOs.Response;

namespace CalculateVatAPI.Services.Interfaces
{
    public interface ICountriesService
    {
        List<CountryResponse> GetCountries();
    }
}
