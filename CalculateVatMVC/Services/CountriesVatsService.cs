using CalculateVatMVC.Models;
using CalculateVatMVC.Services.Interfaces;
using System.Text.Json;

namespace CalculateVatMVC.Services
{
    public class CountriesVatsService : ICountriesVatsService
    {
        private const string apiEndpoint = "/api/CountriesVats/GetVatsByCountryId/";

        private readonly JsonSerializerOptions _options;
        private readonly IHttpClientFactory _clientFactory;

        private CountryVatViewModel countryVat;
        private IEnumerable<CountryVatViewModel> countriesVats;

        public CountriesVatsService(IHttpClientFactory clientFactory)
        {
            _options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
            _clientFactory = clientFactory;
        }

        public async Task<IEnumerable<CountryVatViewModel>> GetVatsByCountryId(int countryId)
        {
            var client = _clientFactory.CreateClient("CalculaVatAPI");

            using (var response = await client.GetAsync(apiEndpoint + countryId))
            {
                if (response.IsSuccessStatusCode)
                {
                    var apiResponse = await response.Content.ReadAsStreamAsync();

                    //countries = await JsonSerializer.DeserializeAsync<List<CountryViewModel>>(apiResponse, _options);

                    countriesVats = await JsonSerializer
                                   .DeserializeAsync<IEnumerable<CountryVatViewModel>>
                                   (apiResponse, _options);

                }
                else
                {
                    return null;
                }
            }
            return (IEnumerable<CountryVatViewModel>)countriesVats;
        }
    }
}
