using CalculateVatAPI.Services;
using CalculateVatAPI.Services.Interfaces;

namespace CalculateVatAPI.AppServicesExtensions
{
    public static class ServiceCollectionExtensions
    {
        public static WebApplicationBuilder RegisterService(this WebApplicationBuilder builder)
        {
            builder.Services.AddTransient<ICountriesService, CountriesService>();
            builder.Services.AddTransient<ICountriesVatsService, CountriesVatsService>();
            builder.Services.AddTransient<ICalculateService, CalculateService>();
            return builder;
        }
    }
}
