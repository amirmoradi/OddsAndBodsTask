using System;
using System.Collections.Generic;

namespace OddsAndBodsTask.Models
{
    public partial class PeopleSpecies
    {
        public Guid PeopleSpeciesId { get; set; }
        public Guid PeopleId { get; set; }
        public Guid SpeciesId { get; set; }

        public virtual People People { get; set; }
        public virtual Species Species { get; set; }
    }
}
