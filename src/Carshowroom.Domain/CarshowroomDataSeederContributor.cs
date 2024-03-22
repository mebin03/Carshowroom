using System;
using System.Threading.Tasks;
using Carshowroom.Brands;
using Carshowroom.Cars;
using Volo.Abp.Data;
using Volo.Abp.DependencyInjection;
using Volo.Abp.Domain.Repositories;

namespace Carshowroom;

public class CarshowroomDataSeederContributor
    : IDataSeedContributor, ITransientDependency
{
    private readonly IRepository<Car, Guid> _carRepository;
private readonly IBrandRepository _brandRepository;
private readonly BrandManager _brandManager;

public CarshowroomDataSeederContributor(
    IRepository<Car, Guid> carRepository,
    IBrandRepository brandRepository,
    BrandManager brandManager)
{
    _carRepository = carRepository;
    _brandRepository = brandRepository;
    _brandManager = brandManager;
}

public async Task SeedAsync(DataSeedContext context)
{
    if (await _carRepository.GetCountAsync() > 0)
    {
        return;
    }

    var brand1 = await _brandRepository.InsertAsync(
        await _brandManager.CreateAsync(
            "name1",
            1,
            "country1"
        )
    );

    var brand2 = await _brandRepository.InsertAsync(
        await _brandManager.CreateAsync(
            "name2",
            2,
            "country2"
        )
    );

    await _carRepository.InsertAsync(
        new Car
        {
            BrandsId = brand1.Id, // SET THE Brand
            CarId = 1,
            Model = "model1",
            Year = 1987,
            Price = 2500000,
            Brand = Cars.Brand.FordMotor
        },
        autoSave: true
    );

    await _carRepository.InsertAsync(
        new Car
        {
            BrandsId = brand2.Id, // SET THE Brand
            CarId = 2,
            Model = "model2",
            Year = 1954,
            Price = 2300000,
            Brand = Cars.Brand.BMWgroup
        },
        autoSave: true
    );
}
}
