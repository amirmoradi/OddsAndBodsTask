using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace OddsAndBodsTask.Models
{
    public partial class StarWarsContext : DbContext
    {
        public StarWarsContext()
        {
        }

        public StarWarsContext(DbContextOptions<StarWarsContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Film> Film { get; set; }
        public virtual DbSet<FilmPeople> FilmPeople { get; set; }
        public virtual DbSet<FilmPlanet> FilmPlanet { get; set; }
        public virtual DbSet<FilmSpecies> FilmSpecies { get; set; }
        public virtual DbSet<FilmStarShip> FilmStarShip { get; set; }
        public virtual DbSet<FilmVehicle> FilmVehicle { get; set; }
        public virtual DbSet<People> People { get; set; }
        public virtual DbSet<PeopleSpecies> PeopleSpecies { get; set; }
        public virtual DbSet<PeopleStarShip> PeopleStarShip { get; set; }
        public virtual DbSet<PeopleVehicle> PeopleVehicle { get; set; }
        public virtual DbSet<Planet> Planet { get; set; }
        public virtual DbSet<Species> Species { get; set; }
        public virtual DbSet<StarShip> StarShip { get; set; }
        public virtual DbSet<Vehicle> Vehicle { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer(
                    "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\Users\\amirmoradi\\Documents\\GitHub\\OddsAndBodsTask\\OddsAndBodsTask\\Data\\StarWarsExtract.mdf;Integrated Security=True");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Film>(entity =>
            {
                entity.Property(e => e.FilmId).ValueGeneratedNever();

                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.Director)
                    .IsRequired()
                    .HasMaxLength(250);

                entity.Property(e => e.LastUpdatedDate).HasColumnType("datetime");

                entity.Property(e => e.Producer)
                    .IsRequired()
                    .HasMaxLength(250);

                entity.Property(e => e.ReleaseDate).HasColumnType("date");

                entity.Property(e => e.Title)
                    .IsRequired()
                    .HasMaxLength(250);

                entity.Property(e => e.Url)
                    .IsRequired()
                    .HasMaxLength(250);
            });

            modelBuilder.Entity<FilmPeople>(entity =>
            {
                entity.Property(e => e.FilmPeopleId).ValueGeneratedNever();

                entity.HasOne(d => d.Film)
                    .WithMany(p => p.FilmPeople)
                    .HasForeignKey(d => d.FilmId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Film_People");

                entity.HasOne(d => d.People)
                    .WithMany(p => p.FilmPeople)
                    .HasForeignKey(d => d.PeopleId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Film");
            });

            modelBuilder.Entity<FilmPlanet>(entity =>
            {
                entity.Property(e => e.FilmPlanetId).ValueGeneratedNever();

                entity.HasOne(d => d.Film)
                    .WithMany(p => p.FilmPlanet)
                    .HasForeignKey(d => d.FilmId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_FilmPlanet_Film");

                entity.HasOne(d => d.Planet)
                    .WithMany(p => p.FilmPlanet)
                    .HasForeignKey(d => d.PlanetId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_FilmPlanet_Planet");
            });

            modelBuilder.Entity<FilmSpecies>(entity =>
            {
                entity.Property(e => e.FilmSpeciesId).ValueGeneratedNever();

                entity.HasOne(d => d.Film)
                    .WithMany(p => p.FilmSpecies)
                    .HasForeignKey(d => d.FilmId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_FilmSpecies_Film");

                entity.HasOne(d => d.Species)
                    .WithMany(p => p.FilmSpecies)
                    .HasForeignKey(d => d.SpeciesId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_FilmSpecies_Species");
            });

            modelBuilder.Entity<FilmStarShip>(entity =>
            {
                entity.Property(e => e.FilmStarShipId).ValueGeneratedNever();

                entity.HasOne(d => d.Film)
                    .WithMany(p => p.FilmStarShip)
                    .HasForeignKey(d => d.FilmId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_FilmStarShip_Film");

                entity.HasOne(d => d.StarShip)
                    .WithMany(p => p.FilmStarShip)
                    .HasForeignKey(d => d.StarShipId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_FilmStarShip_StarShip");
            });

            modelBuilder.Entity<FilmVehicle>(entity =>
            {
                entity.Property(e => e.FilmVehicleId).ValueGeneratedNever();

                entity.HasOne(d => d.Film)
                    .WithMany(p => p.FilmVehicle)
                    .HasForeignKey(d => d.FilmId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_FilmVehicle_Film");

                entity.HasOne(d => d.Vehicle)
                    .WithMany(p => p.FilmVehicle)
                    .HasForeignKey(d => d.VehicleId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_FilmVehicle_Vehicle");
            });

            modelBuilder.Entity<People>(entity =>
            {
                entity.Property(e => e.PeopleId).ValueGeneratedNever();

                entity.Property(e => e.BirthYear).HasMaxLength(20);

                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.EyeColor).HasMaxLength(50);

                entity.Property(e => e.Gender)
                    .HasMaxLength(10)
                    .IsFixedLength();

                entity.Property(e => e.HairColor).HasMaxLength(50);

                entity.Property(e => e.LastIpdatedDate).HasColumnType("datetime");

                entity.Property(e => e.SkinColor).HasMaxLength(50);

                entity.Property(e => e.Title)
                    .IsRequired()
                    .HasMaxLength(250);
            });

            modelBuilder.Entity<PeopleSpecies>(entity =>
            {
                entity.Property(e => e.PeopleSpeciesId).ValueGeneratedNever();

                entity.HasOne(d => d.People)
                    .WithMany(p => p.PeopleSpecies)
                    .HasForeignKey(d => d.PeopleId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_PeopleSpecies_Film");

                entity.HasOne(d => d.Species)
                    .WithMany(p => p.PeopleSpecies)
                    .HasForeignKey(d => d.SpeciesId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_PeopleSpecies_Species");
            });

            modelBuilder.Entity<PeopleStarShip>(entity =>
            {
                entity.Property(e => e.PeopleStarShipId).ValueGeneratedNever();

                entity.HasOne(d => d.People)
                    .WithMany(p => p.PeopleStarShip)
                    .HasForeignKey(d => d.PeopleId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_PeopleStarShip_People");

                entity.HasOne(d => d.StarShip)
                    .WithMany(p => p.PeopleStarShip)
                    .HasForeignKey(d => d.StarShipId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_PeopleStarShip_StarShip");
            });

            modelBuilder.Entity<PeopleVehicle>(entity =>
            {
                entity.Property(e => e.PeopleVehicleId).ValueGeneratedNever();

                entity.HasOne(d => d.People)
                    .WithMany(p => p.PeopleVehicle)
                    .HasForeignKey(d => d.PeopleId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_PeopleVehicle_People");

                entity.HasOne(d => d.Vehicle)
                    .WithMany(p => p.PeopleVehicle)
                    .HasForeignKey(d => d.VehicleId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_PeopleVehicle_Vehicle");
            });

            modelBuilder.Entity<Planet>(entity =>
            {
                entity.HasKey(e => e.PlaentId)
                    .HasName("PK__Planet__0543CD177584FEE5");

                entity.Property(e => e.PlaentId).ValueGeneratedNever();

                entity.Property(e => e.Climate).HasMaxLength(150);

                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.Gravity).HasMaxLength(20);

                entity.Property(e => e.LastIpdatedDate).HasColumnType("datetime");

                entity.Property(e => e.Title)
                    .IsRequired()
                    .HasMaxLength(250);

                entity.Property(e => e.Url).IsRequired();
            });

            modelBuilder.Entity<Species>(entity =>
            {
                entity.Property(e => e.SpeciesId).ValueGeneratedNever();

                entity.Property(e => e.Classification)
                    .IsRequired()
                    .HasMaxLength(150);

                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.Designation).HasMaxLength(150);

                entity.Property(e => e.EyeColot).HasMaxLength(100);

                entity.Property(e => e.HairColor).HasMaxLength(100);

                entity.Property(e => e.Language)
                    .IsRequired()
                    .HasMaxLength(150);

                entity.Property(e => e.LastIpdatedDate).HasColumnType("datetime");

                entity.Property(e => e.SkinColor).HasMaxLength(100);

                entity.Property(e => e.Title)
                    .IsRequired()
                    .HasMaxLength(250);

                entity.Property(e => e.Url).IsRequired();
            });

            modelBuilder.Entity<StarShip>(entity =>
            {
                entity.Property(e => e.StarshipId).ValueGeneratedNever();

                entity.Property(e => e.Consumables)
                    .IsRequired()
                    .HasMaxLength(150);

                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.LastIpdatedDate).HasColumnType("datetime");

                entity.Property(e => e.Manufacturer).HasMaxLength(150);

                entity.Property(e => e.Mglt).HasColumnName("MGLT");

                entity.Property(e => e.Model)
                    .IsRequired()
                    .HasMaxLength(150);

                entity.Property(e => e.StarShipClass).HasMaxLength(50);

                entity.Property(e => e.Title)
                    .IsRequired()
                    .HasMaxLength(250);

                entity.Property(e => e.Url).IsRequired();
            });

            modelBuilder.Entity<Vehicle>(entity =>
            {
                entity.Property(e => e.VehicleId).ValueGeneratedNever();

                entity.Property(e => e.Consumables)
                    .IsRequired()
                    .HasMaxLength(150);

                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.LastIpdatedDate).HasColumnType("datetime");

                entity.Property(e => e.Manufacturer).HasMaxLength(150);

                entity.Property(e => e.Model)
                    .IsRequired()
                    .HasMaxLength(150);

                entity.Property(e => e.Title)
                    .IsRequired()
                    .HasMaxLength(250);

                entity.Property(e => e.Url).IsRequired();

                entity.Property(e => e.VehicleClass).HasMaxLength(50);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
