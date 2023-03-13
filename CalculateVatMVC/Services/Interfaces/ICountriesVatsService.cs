using CalculateVatMVC.Models;

namespace CalculateVatMVC.Services.Interfaces
{
    public interface ICountriesVatsService
    {
        Task<IEnumerable<CountryVatViewModel>> GetVatsByCountryId(int countryId);
    }
}
