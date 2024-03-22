using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp.Application.Dtos;

namespace Carshowroom.Cars
{
    public class BrandLookupDto : EntityDto<Guid>
    {
        
        public string Name { get; set; }
        public int BrandId { get; set; }
        public string Country { get; set; }
    }
}
