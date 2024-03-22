using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Carshowroom.Permissions;
using Microsoft.AspNetCore.Authorization;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Domain.Repositories;

namespace Carshowroom.Brands;

[Authorize(CarshowroomPermissions.Brands.Default)]
public class BrandAppService : CarshowroomAppService, IBrandAppService
{
    private readonly IBrandRepository _brandRepository;
    private readonly BrandManager _brandManager;

    public BrandAppService(
        IBrandRepository brandRepository,
       BrandManager brandManager)
    {
        _brandRepository = brandRepository;
        _brandManager = brandManager;
    }

    //...SERVICE METHODS WILL COME HERE...
    public async Task<BrandDto> GetAsync(Guid id)
    {
        var brand = await _brandRepository.GetAsync(id);
        return ObjectMapper.Map<Brand, BrandDto>(brand);
    }


    public async Task<PagedResultDto<BrandDto>> GetListAsync(GetBrandListDto input)
    {
        if (input.Sorting.IsNullOrWhiteSpace())
        {
            input.Sorting = nameof(Brand.Name);
        }

        var brands = await _brandRepository.GetListAsync(
            input.SkipCount,
            input.MaxResultCount,
            input.Sorting,
            input.Filter
        );

        var totalCount = input.Filter == null
            ? await _brandRepository.CountAsync()
            : await _brandRepository.CountAsync(
               brand => brand.Name.Contains(input.Filter));

        return new PagedResultDto<BrandDto>(
            totalCount,
            ObjectMapper.Map<List<Brand>, List<BrandDto>>(brands)
        );
    }


    [Authorize(CarshowroomPermissions.Brands.Create)]
    public async Task<BrandDto> CreateAsync(CreateBrandDto input)
    {
        var brand = await _brandManager.CreateAsync(
            input.Name,
            input.BrandId,
            input.Country
        );

        await _brandRepository.InsertAsync(brand);

        return ObjectMapper.Map<Brand, BrandDto>(brand);
    }


    [Authorize(CarshowroomPermissions.Brands.Edit)]
    public async Task UpdateAsync(Guid id, UpdateBrandDto input)
    {
        var brand = await _brandRepository.GetAsync(id);

        if (brand.Name != input.Name)
        {
            await _brandManager.ChangeNameAsync(brand, input.Name);
        }

        brand.BrandId = input.BrandId;
        brand.Country = input.Country;

        await _brandRepository.UpdateAsync(brand);
    }


    [Authorize(CarshowroomPermissions.Brands.Delete)]
    public async Task DeleteAsync(Guid id)
    {
        await _brandRepository.DeleteAsync(id);
    }

}
