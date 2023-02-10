using AutoMapper;
using CalculateVatAPI.Context;
using CalculateVatAPI.DTOs.Response;
using CalculateVatAPI.Models;
using CalculateVatAPI.Services.Interfaces;

namespace CalculateVatAPI.Services
{
    public class CountriesVatsService : ICountriesVatsService
    {
        private readonly AppDbContext _db;
        private readonly IMapper _mapper;

        public CountriesVatsService(AppDbContext db, IMapper mapper)
        {
            _db = db;
            _mapper = mapper;
        }

        public List<CountryVatResponse> GetVatsByCountryId(int countryId)
        {
            var countriesVatsResponse = new List<CountryVatResponse>();
            var country = _db.Countries.Find(countryId);
            if (country != null)
            {
                var vats = _db.CountriesVats.Where(a => a.CountryId == countryId).ToList();
                if (vats != null)
                {
                    countriesVatsResponse = _mapper.Map<List<CountryVatResponse>>(vats);
                }
            }
            return countriesVatsResponse;
        }
    }
}
