using AutoMapper;
using TaxiDetails;
using WebApi.DTO;

namespace WebApi;

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
