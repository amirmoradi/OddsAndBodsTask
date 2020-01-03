using System;
using System.Collections.Generic;

namespace OddsAndBodsTask.Models
{
    public partial class Planet
    {
        public Planet()
        {
            FilmPlanet = new HashSet<FilmPlanet>();
        }

        public Guid PlaentId { get; set; }
        public int FriendlyId { get; set; }
        public string Title { get; set; }
        public string RotationPeriod { get; set; }
        public string OrbitalPeriod { get; set; }
        public string Diameter { get; set; }
        public string Climate { get; set; }
        public string Gravity { get; set; }
        public string Terrain { get; set; }
        public string SurfaceWater { get; set; }
        public string Population { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime LastIpdatedDate { get; set; }
        public string Url { get; set; }

        public virtual ICollection<FilmPlanet> FilmPlanet { get; set; }
    }
}
