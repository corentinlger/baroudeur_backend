using System;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;

namespace baroudeurs.Models
{
    public class PointOfInterest
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public bool IsEssential { get; set; }
        public Theme Theme { get; set; }
        public PointType PointType { get; set; }
        public string Latitude { get; set; }
        public string Longitude { get; set; }
        public City City { get; set; }
        public int CityId { get; set; }
        public ICollection<Discovery> Discoveries { get; set; }

    }
}