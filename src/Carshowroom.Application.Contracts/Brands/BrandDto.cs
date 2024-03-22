using System;
using Volo.Abp.Application.Dtos;

namespace Carshowroom.Brands;

public class BrandDto : EntityDto<Guid>
{
    public string Name { get; set; }

    public int BrandId { get; set; }

    public string Country { get; set; }
}
