using Volo.Abp;

namespace Carshowroom.Brands;

public class BrandAlreadyExistsException : BusinessException
{
    public BrandAlreadyExistsException(string name)
        : base(CarshowroomDomainErrorCodes.BrandAlreadyExists)
    {
        WithData("name", name);
    }
}
