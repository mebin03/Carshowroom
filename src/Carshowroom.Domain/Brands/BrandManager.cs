using System;
using System.Threading.Tasks;
using JetBrains.Annotations;
using Volo.Abp;
using Volo.Abp.Domain.Services;

namespace Carshowroom.Brands;

public class BrandManager : DomainService
{
    private readonly IBrandRepository _brandRepository;

    public BrandManager(IBrandRepository brandRepository)
    {
        _brandRepository = brandRepository;
    }

    public async Task<Brand> CreateAsync(
        string name,
        int brandId,
        string? country = null)
    {
        Check.NotNullOrWhiteSpace(name, nameof(name));

        var existingBrand = await _brandRepository.FindByNameAsync(name);
        if (existingBrand != null)
        {
            throw new BrandAlreadyExistsException(name);
        }

        return new Brand(
            GuidGenerator.Create(),
            name,
            brandId,
            country
        );
    }

    public async Task ChangeNameAsync(
        Brand brand,
        string newName)
    {
        Check.NotNull(brand, nameof(brand));
        Check.NotNullOrWhiteSpace(newName, nameof(newName));

        var existingBrand = await _brandRepository.FindByNameAsync(newName);
        if (existingBrand != null && existingBrand.Id != brand.Id)
        {
            throw new BrandAlreadyExistsException(newName);
        }

        brand.ChangeName(newName);
    }
}
