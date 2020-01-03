using System;
using System.Collections.Generic;

namespace OddsAndBodsTask.Models
{
    public partial class FilmPeople
    {
        public Guid FilmPeopleId { get; set; }
        public Guid FilmId { get; set; }
        public Guid PeopleId { get; set; }

        public virtual Film Film { get; set; }
        public virtual People People { get; set; }
    }
}
