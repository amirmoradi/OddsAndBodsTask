using System.Collections.Generic;
using System.Linq;
using OddsAndBodsTask.Models;

namespace OddsAndBodsTask.DAL
{
    public class PeopleRepository
    {
        public static bool PeopleExist(string url)
        {
            using (var context = new StarWarsContext())
            {
                return context.People.Any(x => x.Url == url);
            }
        }

        public static People GetPeople(string url)
        {
            using (var context = new StarWarsContext())
            {
                return context.People.FirstOrDefault(x => x.Url == url);
            }
        }

        public static void Insert(List<People> entities)
        {
            using (var context = new StarWarsContext())
            {
                context.People.AddRange(entities);
                context.SaveChanges();
            }
        }

        public static void Insert(List<PeopleSpecies> entities)
        {
            using (var context = new StarWarsContext())
            {
                context.PeopleSpecies.AddRange(entities);
                context.SaveChanges();
            }
        }

        public static void Insert(List<PeopleStarShip> entities)
        {
            using (var context = new StarWarsContext())
            {
                context.PeopleStarShip.AddRange(entities);
                context.SaveChanges();
            }
        }

        public static void Insert(List<PeopleVehicle> entities)
        {
            using (var context = new StarWarsContext())
            {
                context.PeopleVehicle.AddRange(entities);
                context.SaveChanges();
            }
        }
    }
}
