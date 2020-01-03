using System;
using System.Collections.Generic;

namespace OddsAndBodsTask.Models
{
    public partial class People
    {
        public People()
        {
            FilmPeople = new HashSet<FilmPeople>();
            PeopleSpecies = new HashSet<PeopleSpecies>();
            PeopleStarShip = new HashSet<PeopleStarShip>();
            PeopleVehicle = new HashSet<PeopleVehicle>();
        }

        public Guid PeopleId { get; set; }
        public int FriendlyId { get; set; }
        public string Title { get; set; }
        public string Height { get; set; }
        public string Mass { get; set; }
        public string HairColor { get; set; }
        public string SkinColor { get; set; }
        public string EyeColor { get; set; }
        public string BirthYear { get; set; }
        public string Gender { get; set; }
        public Guid? HomeWorldId { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime LastIpdatedDate { get; set; }
        public string Url { get; set; }

        public virtual ICollection<FilmPeople> FilmPeople { get; set; }
        public virtual ICollection<PeopleSpecies> PeopleSpecies { get; set; }
        public virtual ICollection<PeopleStarShip> PeopleStarShip { get; set; }
        public virtual ICollection<PeopleVehicle> PeopleVehicle { get; set; }
    }
}
