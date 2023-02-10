using CalculateVatAPI.DTOs.Response;

namespace CalculateVatAPI.Services.Interfaces
{
    public interface ICountriesVatsService
    {
        List<CountryVatResponse> GetVatsByCountryId(int countryId);
    }
}
