using AutoMapper;
using Carshowroom.Brands;
using Carshowroom.Cars;

namespace Carshowroom;

public class CarshowroomApplicationAutoMapperProfile : Profile
{
    public CarshowroomApplicationAutoMapperProfile()
    {
        /* You can configure your AutoMapper mapping configuration here.
         * Alternatively, you can split your mapping configurations
         * into multiple profile classes for a better organization. */
        CreateMap<Car, CarDto>();
        CreateMap<CreateUpdateCarDto, Car>();
        CreateMap<Brands.Brand, BrandDto>();
        CreateMap<Brands.Brand, BrandLookupDto>();

    }
}
