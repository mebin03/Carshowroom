using System;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;

namespace Carshowroom.Brands;

public interface IBrandAppService : IApplicationService
{
    Task<BrandDto> GetAsync(Guid id);

    Task<PagedResultDto<BrandDto>> GetListAsync(GetBrandListDto input);

    Task<BrandDto> CreateAsync(CreateBrandDto input);

    Task UpdateAsync(Guid id, UpdateBrandDto input);

    Task DeleteAsync(Guid id);
}
