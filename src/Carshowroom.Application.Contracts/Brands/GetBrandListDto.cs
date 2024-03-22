using Volo.Abp.Application.Dtos;

namespace Carshowroom.Brands;

public class GetBrandListDto : PagedAndSortedResultRequestDto
{
    public string? Filter { get; set; }
}
