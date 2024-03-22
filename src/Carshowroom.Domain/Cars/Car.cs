using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Domain.Entities.Auditing;

namespace Carshowroom.Cars;

public class Car : AuditedAggregateRoot<Guid>
{
    public Guid BrandsId { get; set; }

    public int CarId { get; set; }
    public string Model { get; set; }
    public int Year { get; set; }
    public double Price { get; set; }
    public Brand Brand { get; set; }
}