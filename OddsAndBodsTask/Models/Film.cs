using System;
using System.Collections.Generic;

namespace OddsAndBodsTask.Models
{
    public partial class Film
    {
        public Film()
        {
            FilmPeople = new HashSet<FilmPeople>();
            FilmPlanet = new HashSet<FilmPlanet>();
            FilmSpecies = new HashSet<FilmSpecies>();
            FilmStarShip = new HashSet<FilmStarShip>();
            FilmVehicle = new HashSet<FilmVehicle>();
        }

        public Guid FilmId { get; set; }
        public int FriendlyId { get; set; }
        public string Title { get; set; }
        public int EpisodesNumber { get; set; }
        public string OpenningCrawl { get; set; }
        public string Director { get; set; }
        public string Producer { get; set; }
        public DateTime ReleaseDate { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime LastUpdatedDate { get; set; }
        public string Url { get; set; }

        public virtual ICollection<FilmPeople> FilmPeople { get; set; }
        public virtual ICollection<FilmPlanet> FilmPlanet { get; set; }
        public virtual ICollection<FilmSpecies> FilmSpecies { get; set; }
        public virtual ICollection<FilmStarShip> FilmStarShip { get; set; }
        public virtual ICollection<FilmVehicle> FilmVehicle { get; set; }
    }
}
