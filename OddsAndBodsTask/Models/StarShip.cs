using System;
using System.Collections.Generic;

namespace OddsAndBodsTask.Models
{
    public partial class StarShip
    {
        public StarShip()
        {
            FilmStarShip = new HashSet<FilmStarShip>();
            PeopleStarShip = new HashSet<PeopleStarShip>();
        }

        public Guid StarshipId { get; set; }
        public int FriendlyId { get; set; }
        public string Title { get; set; }
        public string Model { get; set; }
        public string Manufacturer { get; set; }
        public string CreditCost { get; set; }
        public string Lenght { get; set; }
        public string MaxAtmospheringSpeed { get; set; }
        public string Crew { get; set; }
        public string Passengers { get; set; }
        public string CargoCapacity { get; set; }
        public string Consumables { get; set; }
        public string HyperDriveRating { get; set; }
        public string Mglt { get; set; }
        public string StarShipClass { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime LastIpdatedDate { get; set; }
        public string Url { get; set; }

        public virtual ICollection<FilmStarShip> FilmStarShip { get; set; }
        public virtual ICollection<PeopleStarShip> PeopleStarShip { get; set; }
    }
}
