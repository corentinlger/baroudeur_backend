using System;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;

namespace baroudeurs.Models
{
    public class Discovery
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }
        public int PointId { get; set; }
        public PointOfInterest Point { get; set; }

        [DataType(DataType.Date)]
        public DateTime TimeOfDiscovery { get; set; }
    }
}