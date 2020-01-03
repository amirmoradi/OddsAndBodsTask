using System;
using System.Collections.Generic;

namespace OddsAndBodsTask.Models
{
    public partial class PeopleVehicle
    {
        public Guid PeopleVehicleId { get; set; }
        public Guid PeopleId { get; set; }
        public Guid VehicleId { get; set; }

        public virtual People People { get; set; }
        public virtual Vehicle Vehicle { get; set; }
    }
}
