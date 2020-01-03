using System.Collections.Generic;
using System.Linq;
using OddsAndBodsTask.Models;

namespace OddsAndBodsTask.DAL
{
    public class FilmRepository
    {
        public static bool FilmExist(string url)
        {
            using (var context = new StarWarsContext())
            {
                return context.Film.Any(x => x.Url == url);
            }
        }

        public static Film GetFilm(string url)
        {
            using (var context = new StarWarsContext())
            {
                return context.Film.FirstOrDefault(x => x.Url == url);
            }
        }

        public static void Insert(List<Film> entities)
        {
            using (var context = new StarWarsContext())
            {
                context.Film.AddRange(entities);
                context.SaveChanges();
            }
        }

        //public static void Insert(List<FilmPeople> entities)
        //{
        //    using (var context = new StarWarsContext())
        //    {
        //        context.FilmPeople.AddRange(entities);
        //        context.SaveChanges();
        //    }
        //}

        //public static void Insert(List<FilmPlanet> entities)
        //{
        //    using (var context = new StarWarsContext())
        //    {
        //        context.FilmPlanet.AddRange(entities);
        //        context.SaveChanges();
        //    }
        //}

        //public static void Insert(List<FilmSpecies> entities)
        //{
        //    using (var context = new StarWarsContext())
        //    {
        //        context.FilmSpecies.AddRange(entities);
        //        context.SaveChanges();
        //    }
        //}

        //public static void Insert(List<FilmStarShip> entities)
        //{
        //    using (var context = new StarWarsContext())
        //    {
        //        context.FilmStarShip.AddRange(entities);
        //        context.SaveChanges();
        //    }
        //}

        //public static void Insert(List<FilmVehicle> entities)
        //{
        //    using (var context = new StarWarsContext())
        //    {
        //        context.FilmVehicle.AddRange(entities);
        //        context.SaveChanges();
        //    }
        //}
    }
}
