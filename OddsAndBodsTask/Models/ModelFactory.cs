using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using OddsAndBodsTask.DAL;
using OddsAndBodsTask.Models.ResponseModels;

namespace OddsAndBodsTask.Models
{
    /// <summary>
    /// This Class is used to handle the mapping between API responses and DB contents 
    /// </summary>
    public class ModelFactory
    {
        /// <summary>
        /// Generate New Films. 
        /// </summary>
        /// <param name="films">List of FilmResponseItemModel</param>
        /// <returns>List of Film</returns>
        public static List<Film> GenerateNewFilms(List<FilmResponseItemModel> films)
        {
            return (from f in films
                select new Film
                {
                    Url = f.url,
                    CreatedDate = f.created,
                    Director = f.director,
                    EpisodesNumber = f.episode_id,
                    FilmId = Guid.NewGuid(),
                    LastUpdatedDate = f.edited,
                    OpenningCrawl = f.opening_crawl,
                    Producer = f.producer,
                    ReleaseDate = f.release_date,
                    Title = f.title,
                    FriendlyId = GetFriendlyIdFromUrl(f.url),
                }).ToList();
        }

        /// <summary>
        /// Generate New People
        /// </summary>
        /// <param name="people">List of PeopleResponseItemModel</param>
        /// <returns>List of People</returns>
        public static List<People> GenerateNewPeople(List<PeopleResponseItemModel> people)
        {
            var response = new List<People>();

            foreach (var p in people)
            {
                var peopleId = Guid.NewGuid();
                response.Add(new People
                {
                    Url = p.url,
                    Title = p.name,
                    FriendlyId = GetFriendlyIdFromUrl(p.url),
                    CreatedDate = p.created,
                    BirthYear = p.birth_year,
                    EyeColor = p.eye_color,
                    Gender = p.gender,
                    HairColor = p.hair_color,
                    Height = p.height,
                    LastIpdatedDate = p.edited,
                    Mass = p.mass,
                    PeopleId = peopleId,
                    SkinColor = p.skin_color,
                    HomeWorldId = p.homeworld != null
                        ? PlanetRepository.GetPlanet(p.homeworld).PlaentId
                        : (Guid?) null,
                    FilmPeople = GenerateNewFilmPeople(peopleId, p.films),
                    PeopleVehicle = GenerateNewPeopleVehicles(peopleId, p.vehicles),
                    PeopleStarShip = GenerateNewPeopleStarships(peopleId, p.starships),
                    PeopleSpecies = GenerateNewPeopleSpecies(peopleId, p.species)
                });
            }

            return response;
        }

        /// <summary>
        /// Generate New Planets
        /// </summary>
        /// <param name="planets">List of PlanetResponseItemModel</param>
        /// <returns>List of Planet</returns>
        internal static List<Planet> GenerateNewPlanets(List<PlanetResponseItemModel> planets)
        {
            var response = new List<Planet>();

            foreach (var p in planets)
            {
                var plantId = Guid.NewGuid();
                response.Add(new Planet
                {
                    Url = p.url,
                    FriendlyId = GetFriendlyIdFromUrl(p.url),
                    Title = p.name,
                    CreatedDate = p.created,
                    LastIpdatedDate = p.edited,
                    Climate = p.climate,
                    Diameter = p.diameter,
                    Gravity = p.gravity,
                    OrbitalPeriod = p.orbital_period,
                    Population = p.population,
                    RotationPeriod = p.rotation_period,
                    SurfaceWater = p.surface_water,
                    Terrain = p.terrain,
                    PlaentId = plantId,
                    FilmPlanet = GenerateNewFilmPlanets(plantId, p.films),
                });
            }

            return response;
        }

        /// <summary>
        /// Generate New Species
        /// </summary>
        /// <param name="species">List of SpeciesResponseItemModel</param>
        /// <returns>List of Species</returns>
        internal static List<Species> GenerateNewSpecies(List<SpeciesResponseItemModel> species)
        {
            var response = new List<Species>();

            foreach (var s in species)
            {
                var speciesId = Guid.NewGuid();
                response.Add(new Species
                {
                    Title = s.name,
                    FriendlyId = GetFriendlyIdFromUrl(s.url),
                    CreatedDate = s.created,
                    Url = s.url,
                    LastIpdatedDate = s.edited,
                    SkinColor = s.skin_colors,
                    HairColor = s.hair_colors,
                    AverageHeight = s.average_height,
                    AverageLifeSpan = s.average_lifespan,
                    Classification = s.classification,
                    Designation = s.designation,
                    EyeColot = s.eye_colors,
                    Language = s.language,
                    SpeciesId = speciesId,
                    HomeWorldPlentId = s.homeworld != null
                        ? PlanetRepository.GetPlanet(s.homeworld).PlaentId
                        : (Guid?) null,
                    FilmSpecies = GenerateNewFilmSpecies(speciesId, s.films),
                });
            }

            return response;
        }

        /// <summary>
        /// Generate New Vehicles
        /// </summary>
        /// <param name="vehicles">List of VehicleResponseItemModel</param>
        /// <returns>List of Vehicle</returns>
        internal static List<Vehicle> GenerateNewVehicles(List<VehicleResponseItemModel> vehicles)
        {
            var response = new List<Vehicle>();

            foreach (var v in vehicles)
            {
                var vehicleId = Guid.NewGuid();
                response.Add(new Vehicle
                {
                    CreatedDate = v.created,
                    FriendlyId = GetFriendlyIdFromUrl(v.url),
                    Title = v.name,
                    Url = v.url,
                    LastIpdatedDate = v.edited,
                    Lenght = v.length,
                    MaxAtmospheringSpeed = v.max_atmosphering_speed,
                    Model = v.model,
                    CreditCost = v.cost_in_credits,
                    Manufacturer = v.manufacturer,
                    Consumables = v.consumables,
                    CargoCapacity = v.cargo_capacity,
                    Passengers = v.passengers,
                    Crew = v.crew,
                    VehicleClass = v.vehicle_class,
                    VehicleId = vehicleId,
                    FilmVehicle = GenerateNewFilmVehicles(vehicleId, v.films),
                });
            }

            return response;
        }

        /// <summary>
        /// Generate New StarShips
        /// </summary>
        /// <param name="starShips">List of StarshipResponseItemModel</param>
        /// <returns>List of StarShip</returns>
        internal static List<StarShip> GenerateNewStarShips(List<StarshipResponseItemModel> starShips)
        {
            var response = new List<StarShip>();

            foreach (var s in starShips)
            {
                var starshipId = Guid.NewGuid();
                response.Add(new StarShip
                {
                    FriendlyId = GetFriendlyIdFromUrl(s.url),
                    CreatedDate = s.created,
                    Title = s.name,
                    Url = s.url,
                    LastIpdatedDate = s.edited,
                    CargoCapacity = s.cargo_capacity,
                    Consumables = s.consumables,
                    CreditCost = s.cost_in_credits,
                    Crew = s.crew,
                    HyperDriveRating = s.hyperdrive_rating,
                    Lenght = s.length,
                    Manufacturer = s.manufacturer,
                    MaxAtmospheringSpeed = s.max_atmosphering_speed,
                    Mglt = s.MGLT,
                    Model = s.model,
                    Passengers = s.passengers,
                    StarShipClass = s.starship_class,
                    StarshipId = starshipId,
                    FilmStarShip = GenerateNewFilmStarships(starshipId, s.films)
                });
            }

            return response;
        }


        #region Relationships

        /// <summary>
        /// Generate New Film Starships
        /// </summary>
        /// <param name="starshipId"></param>
        /// <param name="films"></param>
        /// <returns></returns>
        private static List<FilmStarShip> GenerateNewFilmStarships(Guid starshipId, List<string> films)
        {
            if (films == null)
                return new List<FilmStarShip>();

            return (from f in films
                select new FilmStarShip
                {
                    FilmId = FilmRepository.GetFilm(f).FilmId,
                    FilmStarShipId = Guid.NewGuid(),
                    StarShipId = starshipId
                }).ToList();
        }

        /// <summary>
        /// Generate New Film Vehicles
        /// </summary>
        /// <param name="vehicleId">Guid</param>
        /// <param name="films">List of Film URLs</param>
        /// <returns>List of FilmVehicle</returns>
        private static List<FilmVehicle> GenerateNewFilmVehicles(Guid vehicleId, List<string> films)
        {
            if (films == null)
                return new List<FilmVehicle>();
            return (from f in films
                select new FilmVehicle
                {
                    FilmId = FilmRepository.GetFilm(f).FilmId,
                    FilmVehicleId = Guid.NewGuid(),
                    VehicleId = vehicleId
                }).ToList();
        }

        /// <summary>
        /// Generate New Film Species
        /// </summary>
        /// <param name="speciesId">Guid</param>
        /// <param name="films">List of Film URLs</param>
        /// <returns>List of FilmSpecies</returns>
        private static List<FilmSpecies> GenerateNewFilmSpecies(Guid speciesId, List<string> films)
        {
            if(films== null)
                return  new List<FilmSpecies>();
            return (from f in films
                select new FilmSpecies
                {
                    FilmId = FilmRepository.GetFilm(f).FilmId,
                    FilmSpeciesId = Guid.NewGuid(),
                    SpeciesId = speciesId
                }).ToList();
        }

        /// <summary>
        /// Generate New Film Planets
        /// </summary>
        /// <param name="plantId">Guid</param>
        /// <param name="films">List of Film URLs</param>
        /// <returns>List of FilmPlanet</returns>
        private static List<FilmPlanet> GenerateNewFilmPlanets(Guid plantId, List<string> films)
        {
            if (films == null)
                return new List<FilmPlanet>();
            return (from f in films
                select new FilmPlanet
                {
                    FilmId = FilmRepository.GetFilm(f).FilmId,
                    FilmPlanetId = Guid.NewGuid(),
                    PlanetId = plantId
                }).ToList();
        }

        /// <summary>
        /// Generate New People Species
        /// </summary>
        /// <param name="peopleId">Guid</param>
        /// <param name="species">List of Species URLs</param>
        /// <returns></returns>
        private static List<PeopleSpecies> GenerateNewPeopleSpecies(Guid peopleId, List<string> species)
        {
            if (species== null)
                return new List<PeopleSpecies>();

            return (from specy in species
                select new PeopleSpecies
                {
                    SpeciesId = SpeciesRepository.GetSpecies(specy).SpeciesId,
                    PeopleId = peopleId,
                    PeopleSpeciesId = Guid.NewGuid()
                }).ToList();
        }

        /// <summary>
        /// Generate New People Starships
        /// </summary>
        /// <param name="peopleId">Guid</param>
        /// <param name="starships">List of Starship URLs</param>
        /// <returns></returns>
        private static List<PeopleStarShip> GenerateNewPeopleStarships(Guid peopleId, List<string> starships)
        {
            if (starships == null)
                return new List<PeopleStarShip>();
            return (from starship in starships
                select new PeopleStarShip
                {
                    PeopleId = peopleId,
                    PeopleStarShipId = Guid.NewGuid(),
                    StarShipId = StarshipRepository.GetStarShip(starship).StarshipId
                }).ToList();
        }

        /// <summary>
        /// Generate New People Vehicles
        /// </summary>
        /// <param name="peopleId">Guid</param>
        /// <param name="vehicles">List of Vehicle URLs</param>
        /// <returns></returns>
        private static List<PeopleVehicle> GenerateNewPeopleVehicles(Guid peopleId, List<string> vehicles)
        {
            if (vehicles == null)
                return new List<PeopleVehicle>();
            return (from vehicle in vehicles
                select new PeopleVehicle
                {
                    PeopleId = peopleId,
                    PeopleVehicleId = Guid.NewGuid(),
                    VehicleId = VehicleRepository.GetVehicle(vehicle).VehicleId
                }).ToList();
        }

        /// <summary>
        /// Generate New Film People
        /// </summary>
        /// <param name="peopleId">Guid</param>
        /// <param name="films">List of Film URLs</param>
        /// <returns></returns>
        private static List<FilmPeople> GenerateNewFilmPeople(Guid peopleId, List<string> films)
        {
            if (films == null)
                return new List<FilmPeople>();
            return (from f in films
                select new FilmPeople
                {
                    FilmId = FilmRepository.GetFilm(f).FilmId,
                    FilmPeopleId = Guid.NewGuid(),
                    PeopleId = peopleId
                }).ToList();
        }

        #endregion

        #region Private methods

        /// <summary>
        /// Retrieve object friendlyId from URL
        /// </summary>
        /// <param name="url">string URL</param>
        /// <returns>FriendlyId</returns>
        private static int GetFriendlyIdFromUrl(string url)
        {
            return Int32.Parse(Regex.Replace(url, "[^0-9]", ""));
        }

        #endregion
    }
}
