using AutoMapper;
using TaxiDetails.WebApi.DTO;

namespace TaxiDetails.WebApi;

public class Mapping : Profile
{
    public Mapping()
    {
        CreateMap<Car, CarDto>().ReverseMap();
        CreateMap<Driver, DriverDto>().ReverseMap();
        CreateMap<Travel, TravelDto>().ReverseMap();
        CreateMap<User, UserDto>().ReverseMap();
    }
}
