using Microsoft.EntityFrameworkCore;
using OddsAndBodsTask.Models;

namespace OddsAndBodsTask.DAL
{
    public class DataAccessRepository
    {
        /// <summary>
        /// Clearing data 
        /// </summary>
        public static void ClearData()
        {
            using (var context = new StarWarsContext())
            {
                context.Database.ExecuteSqlRaw("DELETE FROM	FilmPeople");
                context.Database.ExecuteSqlRaw("DELETE FROM	Filmplanet");
                context.Database.ExecuteSqlRaw("DELETE FROM filmspecies");
                context.Database.ExecuteSqlRaw("DELETE FROM filmstarship");
                context.Database.ExecuteSqlRaw("DELETE FROM filmvehicle");
                context.Database.ExecuteSqlRaw("DELETE FROM peoplespecies");
                context.Database.ExecuteSqlRaw("DELETE FROM peoplestarship");
                context.Database.ExecuteSqlRaw("DELETE FROM peoplevehicle");
                context.Database.ExecuteSqlRaw("DELETE FROM film");
                context.Database.ExecuteSqlRaw("DELETE FROM people");
                context.Database.ExecuteSqlRaw("DELETE FROM planet");
                context.Database.ExecuteSqlRaw("DELETE FROM species");
                context.Database.ExecuteSqlRaw("DELETE FROM starship");
                context.Database.ExecuteSqlRaw("DELETE FROM vehicle");
                context.SaveChanges();

            }
        }
    }
}
