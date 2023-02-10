using AutoMapper;
using CalculateVatAPI.DTOs.Response;
using CalculateVatAPI.Models;

namespace CalculateVatAPI.DTOs.Mappings
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Country, CountryResponse>().ReverseMap();
            CreateMap<CountryVat, CountryVatResponse>().ReverseMap();
        }
    }
}
