using Carshowroom.Cars;
using AutoMapper;
using Carshowroom.Brands;

namespace Carshowroom.Blazor;

public class CarshowroomBlazorAutoMapperProfile : Profile
{
    public CarshowroomBlazorAutoMapperProfile()
    {
        CreateMap<CarDto, CreateUpdateCarDto>();
        CreateMap<BrandDto, UpdateBrandDto>();

    }
}
