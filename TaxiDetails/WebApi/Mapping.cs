using AutoMapper;
using TaxiDetails.WebApi.DTO;

namespace TaxiDetails.WebApi;

/// <summary>
///mapping of data
/// </summary>
public class Mapping : Profile
{
    /// <summary>
    /// createmaps
    /// </summary>
    public Mapping()
    {
        CreateMap<Car, CarDto>().ReverseMap();
        CreateMap<Driver, DriverDto>().ReverseMap();
        CreateMap<Travel, TravelDto>().ReverseMap();
        CreateMap<User, UserDto>().ReverseMap();
    }
}
