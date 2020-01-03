using System;
using System.Collections.Generic;

namespace OddsAndBodsTask.Models
{
    public partial class FilmSpecies
    {
        public Guid FilmSpeciesId { get; set; }
        public Guid FilmId { get; set; }
        public Guid SpeciesId { get; set; }

        public virtual Film Film { get; set; }
        public virtual Species Species { get; set; }
    }
}
