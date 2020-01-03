using System;
using System.Collections.Generic;

namespace OddsAndBodsTask.Models
{
    public partial class PeopleStarShip
    {
        public Guid PeopleStarShipId { get; set; }
        public Guid PeopleId { get; set; }
        public Guid StarShipId { get; set; }

        public virtual People People { get; set; }
        public virtual StarShip StarShip { get; set; }
    }
}
