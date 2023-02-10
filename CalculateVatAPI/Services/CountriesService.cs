using AutoMapper;
using CalculateVatAPI.Context;
using CalculateVatAPI.DTOs.Response;
using CalculateVatAPI.Services.Interfaces;

namespace CalculateVatAPI.Services
{
    public class CountriesService : ICountriesService
    {
        private readonly AppDbContext _db;
        private readonly IMapper _mapper;

        public CountriesService(AppDbContext db, IMapper mapper)
        {
            _db = db;
            _mapper = mapper;
        }

        public List<CountryResponse> GetCountries()
        {
            var countries = _db.Countries.ToList();
            var countriesResponse = _mapper.Map<List<CountryResponse>>(countries);
            return countriesResponse;
        }
    }
}
