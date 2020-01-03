using System;
using System.Collections.Generic;

namespace OddsAndBodsTask.Models
{
    public partial class FilmPlanet
    {
        public Guid FilmPlanetId { get; set; }
        public Guid FilmId { get; set; }
        public Guid PlanetId { get; set; }

        public virtual Film Film { get; set; }
        public virtual Planet Planet { get; set; }
    }
}
