using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp.Application.Dtos;

namespace Carshowroom.Cars
{
    public class CarDto : AuditedEntityDto<Guid>
    {
        public Guid BrandsId { get; set; }
        public string BrandsName { get; set; }
        public int BrandsBrandId { get; set; }
        public string BrandsCountry { get; set; }
        public int CarId { get; set; }
        public string Model { get; set; }
        public int Year { get; set; }
        public double Price { get; set; }
        public Brand Brand { get; set; }

    }
}
