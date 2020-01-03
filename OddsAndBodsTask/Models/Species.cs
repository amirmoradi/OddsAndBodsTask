using System;
using System.Collections.Generic;

namespace OddsAndBodsTask.Models
{
    public partial class Species
    {
        public Species()
        {
            FilmSpecies = new HashSet<FilmSpecies>();
            PeopleSpecies = new HashSet<PeopleSpecies>();
        }

        public Guid SpeciesId { get; set; }
        public int FriendlyId { get; set; }
        public string Title { get; set; }
        public string Classification { get; set; }
        public string Designation { get; set; }
        public string AverageHeight { get; set; }
        public string SkinColor { get; set; }
        public string HairColor { get; set; }
        public string EyeColot { get; set; }
        public string AverageLifeSpan { get; set; }
        public Guid? HomeWorldPlentId { get; set; }
        public string Language { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime LastIpdatedDate { get; set; }
        public string Url { get; set; }

        public virtual ICollection<FilmSpecies> FilmSpecies { get; set; }
        public virtual ICollection<PeopleSpecies> PeopleSpecies { get; set; }
    }
}
