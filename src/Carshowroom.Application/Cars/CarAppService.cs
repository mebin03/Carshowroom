using Carshowroom.Brands;
using Carshowroom.Permissions;
using Microsoft.AspNetCore.Authorization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Linq.Dynamic.Core;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using Volo.Abp.Domain.Entities;
using Volo.Abp.Domain.Repositories;
using Volo.Abp.ObjectMapping;

namespace Carshowroom.Cars
{
    [Authorize(CarshowroomPermissions.Cars.Default)]
    public class CarAppService :
    CrudAppService<
        Car, //The Book entity
        CarDto, //Used to show books
        Guid, //Primary key of the book entity
        PagedAndSortedResultRequestDto, //Used for paging/sorting
        CreateUpdateCarDto>, //Used to create/update a book
    ICarAppService //implement the IBookAppService
    {
        private readonly IBrandRepository _brandRepository;
        public CarAppService(IRepository<Car, Guid> repository,
            IBrandRepository brandRepository)
         : base(repository)
        {
            _brandRepository = brandRepository;
            GetPolicyName = CarshowroomPermissions.Cars.Default;
            GetListPolicyName = CarshowroomPermissions.Cars.Default;
            CreatePolicyName = CarshowroomPermissions.Cars.Create;
            UpdatePolicyName = CarshowroomPermissions.Cars.Edit;
            DeletePolicyName = CarshowroomPermissions.Cars.Delete;
        }
        public override async Task<CarDto> GetAsync(Guid id)
        {
            //Get the IQueryable<Car> from the repository
            var queryable = await Repository.GetQueryableAsync();

            //Prepare a query to join cars and brands
            var query = from car in queryable
                        join brand in await _brandRepository.GetQueryableAsync() on car.BrandsId equals brand.Id
                        where brand.Id == id
                        select new { car, brand };

            //Execute the query and get the car with brand
            var queryResult = await AsyncExecuter.FirstOrDefaultAsync(query);
            if (queryResult == null)
            {
                throw new EntityNotFoundException(typeof(Car), id);
            }

            var carDto = ObjectMapper.Map<Car, CarDto>(queryResult.car);
            carDto.BrandsName = queryResult.brand.Name;
            carDto.BrandsBrandId = queryResult.brand.BrandId;
            carDto.BrandsCountry = queryResult.brand.Country;
            return carDto;
        }

        public override async Task<PagedResultDto<CarDto>> GetListAsync(PagedAndSortedResultRequestDto input)
        {
            //Get the IQueryable<Car> from the repository
            var queryable = await Repository.GetQueryableAsync();

            //Prepare a query to join cars and brands
            var query = from car in queryable
                        join brand in await _brandRepository.GetQueryableAsync() on car.BrandsId equals brand.Id
                        select new { car, brand };

            //Paging
            query = query
                .OrderBy(NormalizeSorting(input.Sorting))
                .Skip(input.SkipCount)
                .Take(input.MaxResultCount);

            //Execute the query and get a list
            var queryResult = await AsyncExecuter.ToListAsync(query);

            //Convert the query result to a list of CarDto objects
            var carDtos = queryResult.Select(x =>
            {
                var carDto = ObjectMapper.Map<Car, CarDto>(x.car);
                carDto.BrandsName = x.brand.Name;
                carDto.BrandsBrandId = x.brand.BrandId;
                carDto.BrandsCountry = x.brand.Country;
                return carDto;
            }).ToList();

            //Get the total count with another query
            var totalCount = await Repository.GetCountAsync();

            return new PagedResultDto<CarDto>(
                totalCount,
                carDtos
            );
        }

        public async Task<ListResultDto<BrandLookupDto>> GetBrandLookupAsync()
        {
            var brands = await _brandRepository.GetListAsync();

            return new ListResultDto<BrandLookupDto>(
                ObjectMapper.Map<List<Brands.Brand>, List<BrandLookupDto>>(brands)
            );
        }

        private static string NormalizeSorting(string sorting)
        {
            if (sorting.IsNullOrEmpty())
            {
                return $"car.{nameof(Car.Model)}";
            }

            if (sorting.Contains("brandsName", StringComparison.OrdinalIgnoreCase))
            {
                return sorting.Replace(
                    "brandsName",
                    "brand.Name",
                    StringComparison.OrdinalIgnoreCase
                );
            }
            if (sorting.Contains("brandsBrandId", StringComparison.OrdinalIgnoreCase))
            {
                return sorting.Replace(
                    "brandsBrandId",
                    "brand.BrandId",
                    StringComparison.OrdinalIgnoreCase
                );
            }
            if (sorting.Contains("brandsCountry", StringComparison.OrdinalIgnoreCase))
            {
                return sorting.Replace(
                    "brandsCountry",
                    "brand.Country",
                    StringComparison.OrdinalIgnoreCase
                );
            }

            return $"car.{sorting}";
        }
    }
}
    

