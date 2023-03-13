using CalculateVatMVC.Models;

namespace CalculateVatMVC.Services.Interfaces
{
    public interface ICountriesService
    {
        Task<IEnumerable<CountryViewModel>> GetCountries();
    }
}
