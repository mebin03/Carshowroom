using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Carshowroom.Cars
{
    public class CreateUpdateCarDto
    {
        public Guid BrandsId { get; set; }

        [Required]
        public int CarId { get; set; }

        [Required]
        [StringLength(128)]
        public string Model { get; set; } = string.Empty;

        [Required]
        public int Year { get; set; }

        [Required]
        public double Price { get; set; }

        [Required]
        public Brand Brand { get; set; }
    }
}
