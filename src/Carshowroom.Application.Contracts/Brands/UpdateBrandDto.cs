using System;
using System.ComponentModel.DataAnnotations;

namespace Carshowroom.Brands;

public class UpdateBrandDto
{
    [Required]
    [StringLength(BrandConsts.MaxNameLength)]
    public string Name { get; set; } = string.Empty;

    [Required]
    public int BrandId { get; set; }

    public string? Country { get; set; }
}
