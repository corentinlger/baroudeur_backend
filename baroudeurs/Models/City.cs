using System;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;

namespace baroudeurs.Models
{
    public class City
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public ICollection<PointOfInterest> Points { get; set; }

    }
}