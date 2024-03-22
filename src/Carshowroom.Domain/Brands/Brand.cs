using System;
using JetBrains.Annotations;
using Volo.Abp;
using Volo.Abp.Domain.Entities.Auditing;

namespace Carshowroom.Brands;

public class Brand : FullAuditedAggregateRoot<Guid>
{
    public int BrandId { get; set; }
    public string Name { get; set; }
    public string Country { get; set; }


    private Brand()
    {
        /* This constructor is for deserialization / ORM purpose */
    }

    internal Brand(
        Guid id,
        string name,
        int brandId,
        string? country = null)
        : base(id)
    {
        SetName(name);
        BrandId = brandId;
        Country = country;
    }

    internal Brand ChangeName(string name)
    {
        SetName(name);
        return this;
    }

    private void SetName(string name)
    {
        Name = Check.NotNullOrWhiteSpace(
            name,
            nameof(name),
            maxLength: BrandConsts.MaxNameLength
        );
    }
}
