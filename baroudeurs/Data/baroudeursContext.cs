using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using baroudeurs.Models;

    public class baroudeursContext : DbContext
    {
        public baroudeursContext (DbContextOptions<baroudeursContext> options)
            : base(options)
        {
        }

        public DbSet<baroudeurs.Models.City> Cities { get; set; }
        public DbSet<baroudeurs.Models.PointOfInterest> PointOfInterests { get; set; }
        public DbSet<baroudeurs.Models.Discovery> Discoveries { get; set; }
        public DbSet<baroudeurs.Models.User> Users { get; set; }
         protected override void OnModelCreating(ModelBuilder modelBuilder)
       {
           modelBuilder.Entity<City>().ToTable("City");
           modelBuilder.Entity<PointOfInterest>().ToTable("PointOfInterest");
           modelBuilder.Entity<Discovery>().ToTable("Discovery");
           modelBuilder.Entity<User>().ToTable("User");
       }

    }
