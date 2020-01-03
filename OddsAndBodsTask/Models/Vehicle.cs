using System;
using System.Collections.Generic;

namespace OddsAndBodsTask.Models
{
    public partial class Vehicle
    {
        public Vehicle()
        {
            FilmVehicle = new HashSet<FilmVehicle>();
            PeopleVehicle = new HashSet<PeopleVehicle>();
        }

        public Guid VehicleId { get; set; }
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
        public string VehicleClass { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime LastIpdatedDate { get; set; }
        public string Url { get; set; }

        public virtual ICollection<FilmVehicle> FilmVehicle { get; set; }
        public virtual ICollection<PeopleVehicle> PeopleVehicle { get; set; }
    }
}
