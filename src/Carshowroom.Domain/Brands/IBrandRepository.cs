using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories;

namespace Carshowroom.Brands;

public interface IBrandRepository : IRepository<Brand, Guid>
{
    Task<Brand> FindByNameAsync(string name);

    Task<List<Brand>> GetListAsync(
        int skipCount,
        int maxResultCount,
        string sorting,
        string filter = null
    );
}
