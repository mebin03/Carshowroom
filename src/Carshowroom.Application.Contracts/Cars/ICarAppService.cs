using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;

namespace Carshowroom.Cars;

public interface ICarAppService :
    ICrudAppService< //Defines CRUD methods
        CarDto, //Used to show books
        Guid, //Primary key of the book entity
        PagedAndSortedResultRequestDto, //Used for paging/sorting
        CreateUpdateCarDto> //Used to create/update a book
{

    // ADD the NEW METHOD
    Task<ListResultDto<BrandLookupDto>> GetBrandLookupAsync();
}