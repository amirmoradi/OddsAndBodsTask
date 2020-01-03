using System;
using System.Collections.Generic;

namespace OddsAndBodsTask.Models
{
    public partial class FilmVehicle
    {
        public Guid FilmVehicleId { get; set; }
        public Guid FilmId { get; set; }
        public Guid VehicleId { get; set; }

        public virtual Film Film { get; set; }
        public virtual Vehicle Vehicle { get; set; }
    }
}
