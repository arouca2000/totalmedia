using CalculateVatMVC.Models;
using CalculateVatMVC.Services.Interfaces;
using System.Text.Json;

namespace CalculateVatMVC.Services
{
    public class CalculateService : ICalculateService
    {
        private const string apiEndpoint = "/api/Calculate/Calc/";

        private readonly JsonSerializerOptions _options;
        private readonly IHttpClientFactory _clientFactory;

        private CalcViewModel calculate;

        public async Task<CalcViewModel> Calc(CalcViewModel calcRequest)
        {
            var client = _clientFactory.CreateClient("CalculaVatAPI");

            using (var response = await client.PostAsJsonAsync(apiEndpoint, calcRequest))
            {
                if (response.IsSuccessStatusCode)
                {
                    var apiResponse = await response.Content.ReadAsStreamAsync();

                    //countries = await JsonSerializer.DeserializeAsync<List<CountryViewModel>>(apiResponse, _options);

                    calculate = await JsonSerializer
                                   .DeserializeAsync<CalcViewModel>
                                   (apiResponse, _options);

                }
                else
                {
                    return null;
                }
            }
            return (CalcViewModel)calculate;
        }
    }
}
