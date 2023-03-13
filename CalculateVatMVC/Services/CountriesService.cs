using CalculateVatMVC.Models;
using CalculateVatMVC.Services.Interfaces;
using System.Collections.Generic;
using System.Text.Json;

namespace CalculateVatMVC.Services
{
    public class CountriesService : ICountriesService
    {
        private const string apiEndpoint = "/api/Countries/GetCountries/";

        private readonly JsonSerializerOptions _options;
        private readonly IHttpClientFactory _clientFactory;

        private CountryViewModel country;
        private IEnumerable<CountryViewModel> countries;

        public CountriesService(IHttpClientFactory clientFactory)
        {
            _options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
            _clientFactory = clientFactory;
        }

        public async Task<IEnumerable<CountryViewModel>> GetCountries()
        {
            var client = _clientFactory.CreateClient("CalculaVatAPI");

            using (var response = await client.GetAsync(apiEndpoint))
            {
                if (response.IsSuccessStatusCode)
                {
                    var apiResponse = await response.Content.ReadAsStreamAsync();

                    //countries = await JsonSerializer.DeserializeAsync<List<CountryViewModel>>(apiResponse, _options);

                    countries = await JsonSerializer
                                   .DeserializeAsync<IEnumerable<CountryViewModel>>
                                   (apiResponse, _options);

                }
                else
                {
                    return null;
                }
            }
            return (IEnumerable<CountryViewModel>)countries;
        }
    }
}
