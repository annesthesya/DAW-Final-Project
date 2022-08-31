using FinalProject.DAL.Entities;
using FinalProject.DAL.Entities.Configurations;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using ProjectDAL.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace FinalProject.DAL
{
    public class AppDBContext : IdentityDbContext<
        User,
        Role,
        int,
        IdentityUserClaim<int>,
        UserRole,
        IdentityUserLogin<int>,
        IdentityRoleClaim<int>,
        IdentityUserToken<int>
        >
    {

        public AppDBContext(DbContextOptions<AppDBContext> options) : base(options)
        {

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseLoggerFactory(LoggerFactory.Create(builder => builder.AddConsole()));
        }

        public DbSet<Car> Cars { get; set; }
        public DbSet<Client> Clients { get; set; }
        public DbSet<ParkingSpace> ParkingSpaces { get; set; }
        public DbSet<Subscription> Subscriptions { get; set; }
        public DbSet<ClientSubscription> ClientSubscriptions { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfiguration(new CarConfig());
        }

    }
}
