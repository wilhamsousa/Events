using System;
using Domain.Model.Entity;
using Infra.Repository.Context.Configuration;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

#nullable disable

namespace Infra.Repository.Context
{
    public partial class EventContext : DbContext
    {
        public EventContext()
        {
        }

        public EventContext(DbContextOptions<EventContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Event> Event { get; set; }
        public virtual DbSet<Guest> Guest { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                IConfigurationRoot configuration = new ConfigurationBuilder()
                    .SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
                    .AddJsonFile("appsettings.json")
                    .Build();

                optionsBuilder
                    .EnableSensitiveDataLogging()
                    .UseSqlServer(configuration.GetConnectionString("DatabaseConnection"));
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");
            
            new EventConfiguration().Configure(modelBuilder);
            new GuestConfiguration().Configure(modelBuilder);

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
