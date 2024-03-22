using System;
using System.ComponentModel.DataAnnotations;

namespace Carshowroom.Brands;

public class CreateBrandDto
{
    [Required]
    [StringLength(BrandConsts.MaxNameLength)]
    public string Name { get; set; } = string.Empty;

    [Required]
    public int BrandId { get; set; }

    public string? Country { get; set; }
}
