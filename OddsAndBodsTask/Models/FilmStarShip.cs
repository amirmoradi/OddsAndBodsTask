using System;
using System.Collections.Generic;

namespace OddsAndBodsTask.Models
{
    public partial class FilmStarShip
    {
        public Guid FilmStarShipId { get; set; }
        public Guid FilmId { get; set; }
        public Guid StarShipId { get; set; }

        public virtual Film Film { get; set; }
        public virtual StarShip StarShip { get; set; }
    }
}
